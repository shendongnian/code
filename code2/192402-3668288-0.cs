    [DelimitedRecord ("|")]
    public class DataFileRecord
    {
        public string SomeValue1 { get; set; }
        public string SomeValue2 { get; set; }
        public string SomeValue3 { get; set; }
        public string SomeValue4 { get; set; }
        public string SomeValue5 { get; set; }
    }
    /*reading section*/
    var engine = new DelimitedFileEngine<DataFileRecord> ();
    DataFileRecord[] records = engine.ReadFile (path);
