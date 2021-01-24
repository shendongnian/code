public async Task<string> test() {
    string postJson = "{Login = \"user\", Password =  \"pwd\"}";
    HttpContent stringContent = new StringContent(postJson, 
        UnicodeEncoding.UTF8, "application/json");
    HttpResponseMessage result = await Validate(Uri,stringContent);
    var json = result.Content.ReadAsStringAsync().Result;
}
2) block current execution while waiting for this resul, like this...
public string test() {
    string postJson = "{Login = \"user\", Password =  \"pwd\"}";
    HttpContent stringContent = new StringContent(postJson, 
        UnicodeEncoding.UTF8, "application/json");
    HttpResponseMessage result = Validate(Uri,stringContent).Result;
    var json = result.Content.ReadAsStringAsync().Result;
}
Choose the 1st way by default unless you really have an urge to block the calling thread. 
Note that when using 2nd solution in WinForms, WPF or ASP.NET apps you will probably have a deadlock. modifying `Validate` method like this should solve the problem:
response = await client.PostAsync(baseUri,content).ConfigureAwait(false);
