    public BusinessBaseViewModel(string placeId)
    {
        AppearingCommand = new Command(Appearing);
        PlaceId = placeId;
    }
    public ICommand AppearingCommand { get; private set; }
    
    public string PlaceId { get; private set; }
    private ObservableCollection<CompanyProfileModel> _googleGbd;
    public ObservableCollection GoogleGbd
    {
        get { _googleGbd?? (_googleGbd = new ObservableCollection<CompanyProfileModel>()); };
        set 
        {
             if (_googleGdb != value)
             {
                 _googleGdb = value;
                 NotifyPropertyChanged();
             }
        }
    }
    private async void Appearing()
    {
        var companyResult = await ApiGoogle.GetGoogleCompanySelectedDetails(PlaceId);
    
        CompanyProfileModel companyProfile = new CompanyProfileModel
        {
            ContactDetails = companyResult.formatted_phone_number,
            Name = companyResult.name,
            Website = companyResult.website,
        };
        GoogleGbd.Add(companyProfile);
    }
