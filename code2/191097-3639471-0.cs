    public Brasil()
    {
        InitializeComponent();
        this.harborList = new List<vwPortos_SEP>();
    
        DataRetrieverClient webService = new DataRetrieverClient();
        webService.GetCounterCompleted +=
            new EventHandler<GetCounterCompletedEventArgs>(webService_GetCounterCompleted);
        webService.GetCounterAsync();
    }
    void webService_GetCounterCompleted(object sender,
             WebPortos.DataRetrieverReference.GetCounterCompletedEventArgs e)
    {
        webService.GetDataCompleted +=
         new EventHandler<DataRetrieverReference.GetDataCompletedEventArgs>(webService_GetDataCompleted);
    
        for (int i = 0; i < counter; i++)
        {                                
            webService.GetDataAsync(i);
        }
    }
