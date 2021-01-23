    [DelimitedRecord("|")]
    public class Format1
    {
        public string Field1;           
        public string Field2;            
        public string Field3;            
        public string Field4;
    }
    static void Main(string[] args)
    {
        var engine = new DelimitedFileEngine(typeof(Format1));
        // change the delimiter
        engine.Options.Delimiter = ","; 
        // import a comma separated record
        object[] importedObjects = engine.ReadString(@"a,b,c,d");
        foreach (object importedObject in importedObjects)
        {
            if (importedObject is Format1)
            {
                Format1 format1 = (Format1)importedObject;
                // process it (for example, check the values)
                Assert.AreEqual("a", format1.Field1);
                Assert.AreEqual("b", format1.Field2);
                Assert.AreEqual("c", format1.Field3);
                Assert.AreEqual("d", format1.Field4);
            }
        }
    }
