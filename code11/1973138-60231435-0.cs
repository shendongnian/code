    private async void Submit_Button_Click(object sender, RoutedEventArgs e)
    {
        var client = new RestClient("http://apage.com/");
        var request = new RestRequest("api/project");
        request.Method = Method.GET;
    
        request.AddHeader("Accept", "application/json");
    
        client.AddDefaultHeader("Authorization",
            string.Format("Bearer {0}", "token goes here"));
    
        var response = client.Execute(request);
    
        var deserialize = new JsonDeserializer();
        ProjectList output = deserialize.Deserialize<ProjectList>(response);
    
        Project firstProjectInResponse = output.Projects[0];
        firstProjectInResponse.check();
    }
