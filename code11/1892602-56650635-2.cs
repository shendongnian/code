    public class MainViewModel : ViewModelBase
        {
            private IPersonService _personService;
            private ISomeService _someService;
            public MainViewModel(ISomeService someService, IPersonService personService)
            {
                _personService = personService;
                _someService = someService;
                Name = "Slim Shady";
    
                Execute();
            }
    
            public string Name
            {
                get
                {
                    return _personService.Name;
                }
                set
                {
                    _personService.Name = value;
                    OnPropertyChanged();
                }
            }
    
            private void Execute()
            {
                string dupa = _someService.GetTheName(_personService);
                System.Windows.MessageBox.Show(dupa);
                System.Windows.MessageBox.Show(Name);
            }
        }
