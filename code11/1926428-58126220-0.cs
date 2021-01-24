Csharp
using (var reader = new StreamReader("path\\to\\file.csv"))
using (var csv = new CsvReader(reader))
{    
    csv.Configuration.PrepareHeaderForMatch = (string header, int index) => 
        header.Replace("(","").Replace(")","");
    var records = csv.GetRecords<Foo>();
}
