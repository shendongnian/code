    public class neueNachbestellungViewModel: INotifyPropertyChanged
    {
    //public ICommand LoadCombobox => new DelegateCommand<object>(ExecuteLoadCombobox);
    public ICommand ComboboxSelectionChanged => new DelegateCommand<object>(ExecuteComboboxSelectionChanged);
    public Nachbestellung Nachbest { get; set; }
    private object someObject; //DelegateCommand.cs requires an argument
    private ObservableCollection<string> _empf;
            public ObservableCollection<string> Empf
            {
                get { return _empf; }
                set
                {
                    _empf = value;
                    OnPropertyChanged("Empf");
                }
            }
            private string _selValue = "CompanyB"; //default value
            public string SelValue  
            {
                get { return _selValue; }
                set
                {
                    _selValue = value;
                    OnPropertyChanged("SelValue");
     switch (SelValue)
        {
    
            case "CompanyA":
                {
                    Nachbest.Empf_Ansprechpartner = "CompanyA";
                    Nachbest.Empfaenger_Mail = "service@companyA.com";
                }
                break;
    
            case "CompanyB":
                {
                    Nachbest.Empf_Ansprechpartner = "CompanyB";
                    Nachbest.Empfaenger_Mail = "orders@companyB.com";
                }
                break;
    
            case "CompanyC":
                {
                    Nachbest.Empf_Ansprechpartner = "CompanyC";
                    Nachbest.Empfaenger_Mail = "info@companyC.com";
                }
                break;
    
            default:
                MessageBox.Show("Something went wrong with the company selection!");
                break;
        }
    //setting the Empfaenger property here with the current selected value is necessary for the database insert later on!
    Nachbest.Empfaenger = SelValue;
                }
            }
    
     public event PropertyChangedEventHandler PropertyChanged;
            public virtual void OnPropertyChanged(string propertyName)
            {
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
    
    public neueNachbestellungViewModel(string id)
    {
    
        this.Artikel = new ArtikelViewModel();
        this.ArtikelList = new ObservableCollection<Artikel>();
        InitializeReorderModel(id);    
        ExecuteComboboxSelectionChanged(someObject);                        
    }
    
    public void InitializeReorderModel(string id)
    {
        //set the MODEL
        this.Nachbest = new Nachbestellung();
    
        //Retrieve and set some values on *VIEW LOAD*!
        var dbOracle = new Datenbank();
        this.Nachbest.Bv = dbOracle.GetBauvorhaben(hv);
        this.Nachbest.Hv = hv;
        this.Nachbest.Bauleiter = dbOracle.GetBauleiter(hv);
        this.Nachbest.Projektleiter = dbOracle.GetProjektleiter(hv);
    }
    
    private void ExecuteComboboxSelectionChanged(object param)
    {
        Empf = new ObservableCollection<string>()
        {
            "CompanyA",
            "CompanyB",
            "CompanyC"             
        };
    Nachbest.Empf_Ansprechpartner = "CompanyB";
                Nachbest.Empfaenger_Mail = "orders@companyB.com";
                Nachbest.Empfaenger = SelValue; //if this is left out and there is no selection (just the default remaining unchanged!), Nachbest.Empfaenger will be null!
    }
    }
