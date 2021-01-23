    void Main()
    {
    	string reading = "2011.01.07,09:56,1.2985,1.2986,1.2979,1.2981,103";
    
    	var engine = new FileHelperEngine<Reading>();
    
    //engine.Options.Fields.Dump();
    
    	char delimiter = ((DelimitedRecordOptions)engine.Options).Delimiter.ToCharArray().First();
    
    	int expectedDelimiterCount = engine.Options.Fields.Sum(field => field.FieldType == typeof(DateTime) ? 2 : field.ArrayMinLength == 0 ? 1 : field.ArrayMinLength);
    
    	expectedDelimiterCount--; // no ending delimiter
    
    	engine.BeforeReadRecord += (ngin, e) => {
    		
    		int fieldCount = e.RecordLine.Count(c => c == delimiter);
    		
    		if (fieldCount == expectedDelimiterCount)
    		{
    			int delimiterIndex = e.RecordLine.IndexOf(delimiter);
    			
    			if (delimiterIndex > NOT_FOUND)
    			{
    				e.RecordLine = e.RecordLine.Remove(delimiterIndex, 1);			
    			}
    		}
    		
    	};
    	
    	
    	var readings = engine.ReadString(reading);
    	
    	readings.Dump();
    	
    }
    
    const int NOT_FOUND = -1;
    
    // Define other methods and classes here
    [DelimitedRecord(",")]
    class Reading
    {
    	[FieldOrder(1)] 
    	[FieldConverter(ConverterKind.Date, "yyyy.MM.ddHH:mm")]
    	public DateTime CollectionDate { get; set; }
    	
    	[FieldOrder(2)] 
    	[FieldArrayLength(4)]
        public decimal[] Data;
    	
    	[FieldOrder(3)] 
    	public int CollectorID { get; set; }
    }
