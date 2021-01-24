csahrp
var serializer = new DataContractJsonSerializer(typeof(Article));
Here is the main problem, the obtained json string should be of type `NewsResponse`, so it should be like this:
csharp
var serializer = new DataContractJsonSerializer(typeof(Article));
---
This is a complete process:
**News.cs**
csharp
public class NewsApi
{
    public async static Task<List<Article>> GetArticlesMain()
    {
        var http = new HttpClient();
        var response = await http.GetAsync("your_news_url");
        var result = await response.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<NewsResponse>(result);
        return data.articles;
    }
}
public class NewsResponse
{
    public string status { get; set; }
    public int totalResults { get; set; }
    public List<Article> articles { get; set; }
}
public class Article
{
    public Source source { get; set; }
    public string author { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public string url { get; set; }
    public string urlToImage { get; set; }
    public DateTime publishedAt { get; set; }
    public string content { get; set; }
}
public class Source
{
    public string id { get; set; }
    public string name { get; set; }
}
**News.xaml.cs**
csharp
private async void Page_Loaded(object sender, RoutedEventArgs e)
{
    List<Article> articles = await NewsApi.GetArticlesMain();
    tbContent.Text = articles.First().title;
}
Best regards.
