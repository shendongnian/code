csharp
string AccessToken = lblToken.Text;
HttpClient tRequest = new HttpClient();
tRequest.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
Task<HttpResponseMessage> getTask = tRequest.PostAsJsonAsync(new Uri(strURL).ToString(), TestMaster);
HttpResponseMessage urlContents = await getTask;
Console.WriteLine("urlContents.ToString");
lblEDDR.Text = urlContents.ToString();
Or you convert `TestMaster` to Json and use `PostAsync` with a `StringContent` object. Like so:
csharp
JsonSerializerSettings jss = new JsonSerializerSettings();
string strValue = JsonConvert.SerializeObject(TestMaster, jss);
lblJSon.Text = strValue;        // This Json is valid
StringContent strcontent = new StringContent (strValue);
bytecontent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
string AccessToken = lblToken.Text;
HttpClient tRequest = new HttpClient();
tRequest.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
Task<HttpResponseMessage> getTask = tRequest.PostAsync(new Uri(strURL).ToString(), bytecontent);
HttpResponseMessage urlContents = await getTask;
Console.WriteLine("urlContents.ToString");
lblEDDR.Text = urlContents.ToString();
