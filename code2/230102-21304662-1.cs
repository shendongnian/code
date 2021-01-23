    ..
    // inside fluent LINQ query
    let client = new HttpClient()
    
    // initialise property and discard result
    let @discard = client.DefaultRequestHeaders.Authorization = new  AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes("user:pass")))
    // now work with initialised client according to your logic..
    select client.GetAsync("url").Result.Content.ReadAsStringAsync().Result
