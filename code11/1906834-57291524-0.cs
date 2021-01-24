    @inject HttpClient Http
    
    <Router AppAssembly="typeof(Program).Assembly">
        <NotFoundContent>
            <p>Sorry, there's nothing at this address.</p>
        </NotFoundContent>
    </Router>
    
    @code
    {
        protected override async Task OnInitAsync()
        {            
            string json = await Http.GetStringAsync("/conf.json");
            Console.WriteLine(json);            
        }
    }
