    class UIRelayCommand : RelayCommand, INotifyPropertyChanged
    {
        private static Dictionary<ModifierKeys, string> modifierText = new Dictionary<ModifierKeys, string>()
        {
            {ModifierKeys.None,""},
            {ModifierKeys.Control,"Ctrl+"},
            {ModifierKeys.Control|ModifierKeys.Shift,"Ctrl+Shift+"},
            {ModifierKeys.Control|ModifierKeys.Alt,"Ctrl+Alt+"},
            {ModifierKeys.Control|ModifierKeys.Shift|ModifierKeys.Alt,"Ctrl+Shift+Alt+"},
            {ModifierKeys.Windows,"Win+"}
        };
        private Key _key;
        public Key Key
        {
            get { return _key; }
            set { _key = value; RaisePropertyChanged("Key"); RaisePropertyChanged("GestureText"); }
        }
        private ModifierKeys _modifiers;
        public ModifierKeys Modifiers
        {
            get { return _modifiers; }
            set { _modifiers = value; RaisePropertyChanged("Modifiers"); RaisePropertyChanged("GestureText");}
        }
        public string GestureText
        {
            get { return modifierText[_modifiers] + _key.ToString(); }
        }
        public UIRelayCommand(Action<object> execute, Predicate<object> canExecute, Key key, ModifierKeys modifiers)
            : base(execute, canExecute)
        {
            _key = key;
            _modifiers = modifiers;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
