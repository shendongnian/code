    Inject in .razor
    
    @inject HttpClient http;
    
    @inject NavigationManager navigationManager;
    @using Newtonsoft.Json;
    
    and do post call in razor
    
     var serialized = JsonConvert.SerializeObject(yourmodal);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
    
            var result = await http.PostAsync($"{navigationManager.BaseUri}api/method", stringContent).ConfigureAwait(false);
    
    Setup.cs 
    
      services.AddScoped<HttpClient>();
    
    Controller 
     [HttpPost] 
            public IActionResult Login([FromBody]Model login)
            {
               IActionResult response = Ok(new { result = ''});
            }
    
        
