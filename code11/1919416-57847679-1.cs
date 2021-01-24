    public MainPage() {
        InitializeComponent();
    } 
    
    static Lazy<HttpClient> httpClient = new Lazy<HttpClient>();
    public async Task GetLocations() {        
        var response = await httpClient.Value.GetStringAsync("my API url is here");
        var locations = JsonConvert.DeserializeObject<List<Location>>(response);
        using(SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation)) {
            conn.CreateTable<Location>();
            foreach(var location in locations) {
                conn.Insert(location);
            }
            conn.Close();
        }
    }
    
    //async-void allowed here because this is an event handler.
    private async void Button_Clicked(object sender, EventArgs e) {
        await GetLocations();
    
        //await Navigation.PushAsync(new LocationPage());
        //this code navigates to the next page in the app
    }
