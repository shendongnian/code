    [HttpPost]
    public async Task<ActionResult> Create(PersonVM personData)
    {
     using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:60291/api/WebForm/Post");
    
                    var response = await client.PostAsJsonAsync("personData", personData);
                    return RedirectToAction("Index");
    
                }
    
    }
    
 
       [HttpPost]
        public IHttpActionResult  Post(WebFormDataVM personData)
            {
               // code
            }
