using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyWpfProject.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _greeting;
        public string Greeting
        {
            get => _greeting;
            set => SetField(ref _greeting, value);
        }

        private string _title;
        public string Title
        {
            get => _title;
            set => SetField(ref _title, value);
        }

        public MainWindowViewModel()
        {
            // Updated greeting and a new title property for a stylish look.
            Greeting = "Hi from the ViewModel!";
            Title = "Welcome to My Stylish Application!";
        }

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Helper method to update property values and notify the UI.
        /// </summary>
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
