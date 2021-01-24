    class MyCustomCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        // the rest of the ICommand interface members implemented    
    
        private void HandlePropertyChanged(object sender, NotifyPropertyChangedEventArgs e)
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
