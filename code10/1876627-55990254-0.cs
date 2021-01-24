    var tfsUrl = "http://tfstest01:8080/tfs/{collection}";
    var tfsUri = new Uri(tfsInstance + collectionName + "/{teamProjectGUID}/_apis/git/repositories/?api-version=4.1");
    using (HttpClient client = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true }))
    {
         var data = new { name = "newRepo" };
         var json = JsonConvert.SerializeObject(data);
         var content = new StringContent(json, Encoding.UTF8, "application/json");
         HttpResponseMessage response = null;
         response = client.PostAsync(tfsUri, content).Result;
    }
