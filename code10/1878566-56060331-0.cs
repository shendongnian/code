`C#
    try{
     var Json = Newtonsoft.Json.JsonConvert.SerializeObject(user);
            HttpContent httpContent = new StringContent(Json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/Json");
            var httpClient = new HttpClient();
            //httpClient.GetAsync("windows.digitalgramsoft.com/Api/Home");
            //DisplayAlert("Added", "Your Data has been added", "OK")
            var response =await httpClient.GetStringAsync("http://localhost:40987/Api/Home/Post?username="+username.Text+"&password="+password.Text);
    
    
            var login = JsonConvert.DeserializeObject<List<User>>(response);
    }catch(Exception ex){
    Console.WriteLine(ex.Message);
}
`
Then use a breakpoint to check whats inside the `Exception` object. From there, you can track the source.
