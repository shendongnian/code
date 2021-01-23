    public Page()
    {
    	InitializeComponent();
    
    	DataContext = App.ViewModel;
    
    	this.Loaded += new RoutedEventHandler(Page_Loaded);
    }
    
    void Page_Loaded(object sender, RoutedEventArgs e)
    {
    	App.ViewModel.LoadData();
    
    	var storedStock =
        	new ObservableCollection<WebServiceClass.ItemGetValues>();	
    
    	List.ItemsSource = storedStock;
    	
    	var values =
    		Observable.Using<WebServiceClass.ItemGetValues, GPWWebservicePortTypeClient>
    			(() => new GPWWebservicePortTypeClient(), ws =>
    			{
    				var clientGetLastValue = Observable
    					.FromAsyncPattern<string, GetLastValueCompletedEventArgs>
    					(ws.GetLastValueAsync, ws.GetLastValueResult);
    
    				Func<string, WebServiceClass.ItemGetValues> deserializeFirst = r =>
    					((List<WebServiceClass.ItemGetValues>)JsonConvert
    					.DeserializeObject(r,
    					    typeof(List<WebServiceClass.ItemGetValues>)))
    					.First();
    
    				return
    					from item in App.ViewModel.Items
    					from e in clientGetLastValue(item)
    					select deserializeFirst(e.Result);
    			});
    
    	values.Subscribe(storedStock.Add);
    }
