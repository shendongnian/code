    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    
    namespace FrameworkCanExecuteExample
    {
        public class MainViewModel : INotifyPropertyChanged
        {
            private string connectionString;
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public MainViewModel()
            {
                BtnConfirm = new RelayCommand(Confirm, CanConfirm);
            }
    
            public string ConnectionString
            {
                get => connectionString;
                set
                {
                    connectionString = value;
                    OnPropertyChanged();
                }
            }
    
            public ICommand BtnConfirm { get; }
    
    
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
    
            private void Confirm(object parameter)
            {
            }
    
            private bool CanConfirm(object parameter)
            {
                return !string.IsNullOrWhiteSpace(connectionString);
            }
        }
    }
