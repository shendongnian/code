    public class MyViewModel : INotifyPropertyChanged
    {
        private string _myText = string.Empty;
        private int _maxLength = 6;
        private ICommand _myCommand;
        public MyViewModel()
        {
            this._myCommand = new MySimpleCommand((obj) => { FormatMyText(); });
        }
        private void FormatMyText()
        {
            this.MyText = this.MyText.PadLeft(this.MyLength, '0');
        }
        public string MyText
        {
            get { return this._myText; }
            set
            {
                this._myText = value;
                PropertyChanged(this, new PropertyChangedEventArgs("MyText"));
            }
        }
        public int MyLength
        {
            get { return this._maxLength; }
            set { }
        }
        public ICommand MyCommand
        {
            get { return this._myCommand; }
            set { }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public class MySimpleCommand : ICommand
        {
            private Action<object> _action;
            public MySimpleCommand(Action<object> cmdAction)
            {
                this._action = cmdAction;
            }
            public bool CanExecute(object parameter)
            {
                return true;
            }
            public event EventHandler CanExecuteChanged;
            public void Execute(object parameter)
            {
                _action(parameter);
            }
        }
    }
