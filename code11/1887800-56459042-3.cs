    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]  
 
     public class CSVColumn : Attribute
        {
            public string ImportName { set; get; }
    
            public CSVColumn() { }
    
            public CSVColumn(string _import)
            {
                this.ImportName = _import;
            
            }
        }
