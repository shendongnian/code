 5/13/2019,SPEI ENVIADO SANTANDER/03GASOLINA MAYO (3),"1,000.00",,
 5/13/2019,"TELEFONOS DE MEXICO,/GUIA:54 REF:0000000005556 CIE:041",872,,
           ^                                                      ^
That's a standard way to indicate that whatever is inside the quotes is a single value and shouldn't be split up according any commas inside it. 
That means you need to write your code to split based on commas except when they're inside quotation marks. To do that... don't. Just use an existing library that handles that for you. Try [CsvHelper](https://joshclose.github.io/CsvHelper/).
First define a class that defines the data contained in each row:
    public class Data
    { 
        [Name("D?")]
        public DateTime Date { get; set; }
        [Name("Concepto / Referencia")]
        public string Conceptio { get; set; }
        [Name("cargo")]
        public string Cargo { get; set; }
        [Name("Abono")]
        public string Abono { get; set; }
    }
If the property name matches the column header we don't need the `CsvHelper.Configuration.Attributes.NameAttribute`, but we can't name a property `D?` so we need the attribute.
Then the code to read it looks like this:
    public Data[] ReadDate(string fileName)
    {
        using (var file = File.OpenText(fileName))
        {
            using (var reader = new CsvReader(file))
            {
                return reader.GetRecords<Data>().ToArray();
            }
        }
    }
Now we've got our CSV data parsed into an array of `Data` and we can do whatever we want with that. 
I didn't even add any special handling for the quotation makes because that's the default behavior of CsvHelper. It doesn't try to split values inside quotes. If you need to you can specify a different character, but in this case we're all set.
