    static HttpClient httpClient = new HttpClient();
    event EventHandler appearing = delegate { };
    protected override void OnAppearing()
    {
        base.OnAppearing();
        appearing += onAppearing; //subscribe
        onAppearing(this, EventArgs.Empty);  //raise event      
    }
    private async void onAppearing(object sender, EventArgs args) {
        appearing -= onAppearing; //unsubscribe
        try {//On UI Thread
            var todos = await GetAPIDataFromWeb(); //Background Thread
            todoListView.ItemsSource = todos; //Back on UI Thread
        } catch (Exception exp) {
            Console.WriteLine(exp.Message);
        }        
    }
    
    private async Task<List<Todo>> GetAPIDataFromWeb() {
        List<Todo> todos = new List<Todo>();
        var url = "https://jsonplaceholder.typicode.com/todos";
        var response = await httpClient.GetStringAsync(url);
        if (response != null) {
            todos = JsonConvert.DeserializeObject<List<Todo>>(response);            
        }
        return todos;
    }
