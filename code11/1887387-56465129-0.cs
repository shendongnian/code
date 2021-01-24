csharp
public static void Main(string[] args)
{    
    using (var reader = new StringReader(FunctionThatReturnsCsv()))
    using (var csv = new CsvReader(reader))
    {
        var results = csv.GetRecords<Foo>().ToList();
    }            
}
public static string FunctionThatReturnsCsv()
{
    return "columnA,columnB\ndataA,dataB";
}
public class Foo
{
    public string columnA { get; set; }
    public string columnB { get; set; }
}          
