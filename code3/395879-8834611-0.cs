    class Program
    {
        [DelimitedRecord("|")]
        public class FooBar
        {
            public string ColumnA_One;       
            [FieldIgnored]
            public string ColumnA_Two;        
    
            public string ColumnB_One;        
            [FieldIgnored]
            public string ColumnB_Two;
        }
    
        static void Main(string[] args)
        {
            FileHelperEngine engine = new FileHelperEngine(typeof(FooBar));
            engine.AfterReadRecord += engine_AfterReadRecord;
            FooBar[] records = engine.ReadFile("FileIn.txt") as FooBar[];
        }
    
        static void engine_AfterReadRecord(EngineBase engine, FileHelpers.Events.AfterReadEventArgs<object> e)
        {
            FooBar fooBar = e.Record as FooBar;
            fooBar.ColumnA_Two = fooBar.ColumnA_One;
            fooBar.ColumnB_Two = fooBar.ColumnB_One;
        }
    }
