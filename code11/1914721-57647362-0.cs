c#
interface IParser
{
    Task<byte[]> Parse(Request searchObject);
}
public class CustomersCSVExport : IParser
{
    public Task<byte[]> Parse(Request searchObject)
    {
        throw new System.NotImplementedException();
    }
}
public class ArticlesCSVExport : IParser
{
    public async Task<byte[]> Parse(Request searchObject)
    {
        // Defining file headers
            var columnHeaders = new string[]
               {
                "Article Name",
                "Price",
                "Type",
                "Status"
               };
        
            // Get the data from  Article Service to export/download
            var result = await ArticleService.Get(searchObject);
        
        
            // Escaping "," 
            var articles = (from Article in result
                             select new object[]
                          {        // Could get this values from column headers? 
                                            $"\"{Article.ArticleName}\"",
                                            $"\"{Article.Price}\"",
                                            $"\"{Article.ArticleType}\"",
                                            $"{(Article.Active==true ? "Active" : "Inactive")}",
                          }).ToList();
        
            // Build the file content
            var articlesCsv = new StringBuilder();
        
            articles.ForEach(line =>
            {
                articlesCsv.AppendLine(string.Join(",", line));
            });
        
            byte[] buffer = Encoding.ASCII.GetBytes($"{string.Join(",", columnHeaders)}\r\n{articlesCsv.ToString()}");
            return buffer;
    }
}
class CsvParser
{
    private IParser _parser;
    public void SetParser(IParser parser)
    {
        _parser = parser;
    }
    public Task<byte[]> Parse(Request searchObject)
    {
        return _parser.Parse(searchObject);
    }
}
class Client{
    
    void Main()
    {
        var csvParser= new CsvParser();
        
        csvParser.SetParser(new ArticlesCSVExport());
        var articleResult =csvParser.Parse(new Request());
        
        csvParser.SetParser(new CustomersCSVExport());
        var customerResult = csvParser.Parse(new Request());
    }
}
