csharp
public class MyScrapper : WebScraper
{
    private Queue<String> _urlToParse = new Queue<String>();
    public override void Init()
    {
        _urlToParse.Enqueue("https://stackoverflow.com/");
        _urlToParse.Enqueue("https://stackoverflow.com/nothing");
        _urlToParse.Enqueue("https://google.com/");
        while (_urlToParse.Count > 0)
        {               
            Request(_urlToParse.Dequeue(), Parse);                
        }
    }
    public override void Parse(Response response)
    {            
        Console.WriteLine("Handeling response");
    }
    public override void Log(string Message, LogLevel Type)
    {
        if (Type.HasFlag(LogLevel.Critical) & Message.StartsWith("Url failed permanently"))
        {
            Console.WriteLine($"Logging failed Url: {Message}");
        }
    }
}
