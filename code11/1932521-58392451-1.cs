    public ActionResult GetJsonDataModel()
        {
            var webClient = new WebClient();
            webClient.Headers.Add(HttpRequestHeader.Cookie, "cookievalue");
            var json = webClient.DownloadString(@"https://jsonplaceholder.typicode.com/todos/1");
            Models.JsonModel.RootObject objJson = JsonConvert.DeserializeObject<Models.JsonModel.RootObject>(json); //here we will map the Json to C# class
            //here we will return this model to view
            return View(objJson);  //you have to pass model to view
        }
