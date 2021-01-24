public CustomHttpClient : HttpClient 
{  
    public async Task<T> GetJsonAsync<T>(string requestUri)  
    {  
        HttpClient httpClient = new HttpClient();  
        var httpContent = await httpClient.GetAsync(requestUri);  
        string jsonContent = httpContent.Content.ReadAsStringAsync().Result;  
        T obj = JsonConvert.DeserializeObject<T>(jsonContent);  
        httpContent.Dispose();  
        httpClient.Dispose();  
        return obj;  
    }  
    public async Task<HttpResponseMessage> PostJsonAsync<T>(string requestUri, T content)  
    {  
        HttpClient httpClient = new HttpClient();  
        string myContent = JsonConvert.SerializeObject(content);  
        StringContent stringContent = new StringContent(myContent, Encoding.UTF8, "application/json");  
        var response = await httpClient.PostAsync(requestUri, stringContent);  
        httpClient.Dispose();  
        return response;  
    }  
    public async Task<HttpResponseMessage> PutJsonAsync<T>(string requestUri, T content)  
    {  
        HttpClient httpClient = new HttpClient();  
        string myContent = JsonConvert.SerializeObject(content);  
        StringContent stringContent = new StringContent(myContent, Encoding.UTF8, "application/json");  
        var response = await httpClient.PutAsync(requestUri, stringContent);  
        httpClient.Dispose();  
        return response;  
    }  
}
    
3.Now call in your razor page: 
@inject CustomHttpClient Http
    
@code{  
    
    protected override async Task OnInitializedAsync() {  
        await Http.GetJsonAsync < Emp[] > ("Your Url");  
    } 
    public class Emp
    { 
        public int? ID { get; set; }
        public string EmpName { get; set; }  
    }
}
