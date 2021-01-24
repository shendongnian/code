    public class ObservableCommand<T> : ICommand where T : System.ComponentModel.INotifyPropertyChanged
    {
        Predicate<object> _predicate;
        Action<object> _execute;
        public ObservableCommand(T model, Action<object> execute, Predicate<object> predicate)
        {
            model.PropertyChanged += ModelChanged;
            _execute = execute;
            _predicate = predicate;
        }
        public event EventHandler CanExecuteChanged;
        private void ModelChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
        public bool CanExecute(object parameter)
        {
            return _predicate(parameter);
        }
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    } 
