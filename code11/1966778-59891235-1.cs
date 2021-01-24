    HttpResponseMessage responsePost = GlobalVariables.WebApiClient.PostAsJsonAsync("Account/Register", registerBindingModel).Result;
    MyAPIResponse model=new MyAPIResponse();
    string content=string.Empty;
    
        if (responsePost.IsSuccessStatusCode)
        {
          content = response.Content.ReadAsStringAsync().Result;
          model = JsonConvert.DeserializeObject<MyAPIResponse>(content); 
          //or if you do not want a model structure for the parsing
          //var parsedmodel = JsonConvert.DeserializeObject<dynamic>(content);                   
        }
    
        ViewBag.Message=model.message;
