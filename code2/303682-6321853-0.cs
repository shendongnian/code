    public Window1()
    {
    	InitializeComponent();
    	
    	DataContext = this;
    	
    	this.Countries = new ObservableCollection<Country>();
    	this.Countries.Add(new Country {Id = 1, Name = "United Kingdom" });
    	this.Countries.Add(new Country {Id = 1, Name = "United States" });
    }
    
    public ObservableCollection<Country> Countries {get; set;}
    
    private Country selectedCountry;
    
    public Country SelectedCountry
    {
    	get { return this.selectedCountry; }
    	set 
    	{
    		System.Diagnostics.Debug.WriteLine(string.Format("Selection Changed {0}", value.Name));
    		this.selectedCountry = value;
    	}
    }
