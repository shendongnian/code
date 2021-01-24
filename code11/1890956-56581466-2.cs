csharp
public class QuoteStringConverter : StringConverter
{
    public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
    {
        var innerQuotes = ((string)value).Replace(row.Configuration.QuoteString, row.Configuration.DoubleQuoteString);
        var quotedValue = row.Configuration.Quote + innerQuotes + row.Configuration.Quote;
        return base.ConvertToString(quotedValue, row, memberMapData);
    }
}
Turn quotes off and add your converter to the `TypeConverterCache`
csharp
var rawData = new[]
{
    new TestDTO { Field1 = "Field1", Field2 = 1, Field3 = true },
    new TestDTO { Field1 = "Field2", Field2 = 10, Field3 = false }
};
using (var writer = new StreamWriter("file.csv"))
using (var csv = new CsvWriter(writer))
{
    csv.Configuration.ShouldQuote = (field, context) => false;
    csv.Configuration.TypeConverterCache.AddConverter<string>(new QuoteStringConverter());
    csv.WriteRecords(rawData);
}        
