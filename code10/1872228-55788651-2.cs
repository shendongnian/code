     class MainWindowVM : INotifyPropertyChanged
        {
            public MainWindowVM()
            {
    
                CheckBoxChanged = new RelayCommand(CheckBoxChangedMethod);
    
            }
    
            private string labelContent="Not Yet Checked";
    
            public string LabelContent
            {
                get { return labelContent; }
                set { labelContent = value; OnPropertyChanged(new PropertyChangedEventArgs("LabelContent")); }
            }
    
    
            public void Init()
            {
                try
                {
                    CBItems = new ObservableCollection<ex>();
                    for (int i = 985; i <= 1030; i++)
                        CBItems.Add(new ex { CheckBoxChecked = true });
                }
                catch (Exception ex)
                {
    
                }
            }
    
            public ICommand CheckBoxChanged { get; set; }
           
    
    
            private ObservableCollection<ex> _CBItems;
            public ObservableCollection<ex> CBItems
            {
                get { return _CBItems; }
                set
                {
                    _CBItems = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("CBItems"));
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged(PropertyChangedEventArgs e)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, e);
                }
            }
    
    
            public void CheckBoxChangedMethod(object obj)
            {
                LabelContent = "You have Clicked the checkbox";
            }
    
        }
    
        public class RelayCommand : ICommand
        {
            private Action<object> execute;
            private Func<object, bool> canExecute;
    
            public event EventHandler CanExecuteChanged
            {
                add
                {
                    CommandManager.RequerySuggested += value;
    
                }
                remove { CommandManager.RequerySuggested -= value; }
            }
    
            public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
            {
                this.execute = execute;
                this.canExecute = canExecute;
            }
    
    
            public bool CanExecute(object parameter)
            {
                //return this.canExecute == null || this.canExecute(parameter);
                return true;
            }
    
            public void Execute(object parameter)
            {
                this.execute(parameter);
            }
    
            public RelayCommand(Action<object> execute)
            {
                this.execute = execute;
    
            }
    
    
        }
    
        public class ex
        {
            private bool _checkBoxChecked;
    
            public bool CheckBoxChecked
            {
                get { return _checkBoxChecked; }
                set { _checkBoxChecked = value; }
            }
    
        }
