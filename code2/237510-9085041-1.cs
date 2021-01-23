    // Custom object.
    public class MyCustomObject
    {
        public string StringProperty { get; set; }
        public int IntProperty { get; set; }
    }
    
    // Writing the CSV file.
    var myCustomObjectList = new List<MyCustomObject>
    {
        new MyCustomObject { StringProperty = "one", IntProperty = 1 },
        new MyCustomObject { StringProperty = "two", IntProperty = 2 }
    };
    var csv = new CsvHelper( File.OpenWrite( "some-file.csv" ) );
    csv.Writer.WriteRecords( myCustomObjectList );
