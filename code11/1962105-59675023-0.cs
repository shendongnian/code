    public App()
    {
        getLists();
        this.InitializeComponent();
        this.Suspending += OnSuspending;
    }
    
    public async void getLists() 
    {
        classList = await Files.ReadFromFileAsync<List<Class>>(filePath);
    }
 
