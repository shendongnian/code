    class MyCustomCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
    
        private void HandlePropertyChanged(object sender, NotifyPropertyChangedEventArgs e)
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
