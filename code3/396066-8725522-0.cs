    // The class definition 
    public string mClass =  
    @"  
        [DelimitedRecord(""" + delimiter + @""")]
        public class BaseCustomer
        {
            public int CustId;
    
            public string Name;
            public decimal Balance;
            [FileHelpers.FieldConverter(FileHelpers.ConverterKind.Date, ""ddMMyyyy"")]
            public DateTime AddedDate;
        }
    "; 
 
    Type t = ClassBuilder.ClassFromString(mClass); 
 
    FileHelperEngine engine = new FileHelperEngine(t); 
    
    DataTable = engine.ReadFileAsDT("test.txt"); 
