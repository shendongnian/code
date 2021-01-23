       public partial class MainWindow : Window, INotifyPropertyChanged
        {
    
    
            public MainWindow()
            {
                var jobs1 = new ObservableCollection<Job>()
                                {
                                    new Job() {Start = DateTime.Now, End = DateTime.Now.AddDays(1), Title = "Physical Enginer"},
                                    new Job() {Start = DateTime.Now, End = DateTime.Now.AddDays(1), Title = "Mechanic"}
    
                                };
                var jobs2 = new ObservableCollection<Job>()
                                {
                                    new Job() {Start = DateTime.Now, End = DateTime.Now.AddDays(1), Title = "Doctor"},
                                    new Job() {Start = DateTime.Now, End = DateTime.Now.AddDays(1), Title = "Programmer"}
    
                                };
                var personList = new ObservableCollection<Person>()
                                       {
                                           new Person() {Name = "john", Jobs = jobs1},
                                           new Person() {Name="alan", Jobs=jobs2}
                                       };
    
                this.DataContext = personList;
                InitializeComponent();
            }
    
            private void Validation_OnError(object sender, ValidationErrorEventArgs e)
            {
                if (e.Action == ValidationErrorEventAction.Added)
                    NoOfErrorsOnScreen++;
                else
                    NoOfErrorsOnScreen--;
            }
    
            public bool FormHasNoNoErrors
            {
                get { return _formHasNoErrors; }
                set 
                { 
                    if (_formHasNoErrors != value)
                    {
                        _formHasNoErrors = value;
                         PropertyChanged(this, new PropertyChangedEventArgs("FormHasNoErrors")); 
                    }
                }
            }
    
            public int NoOfErrorsOnScreen
            {
                get { return _noOfErrorsOnScreen; }
                set 
                { 
                    _noOfErrorsOnScreen = value;
                    FormHasNoNoErrors = _noOfErrorsOnScreen == 0 ? true : false;
                }
            }
    
            private int _noOfErrorsOnScreen = 0;
            private bool _formHasNoErrors = true;
    
            public event PropertyChangedEventHandler PropertyChanged = delegate {};
        }
