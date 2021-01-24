    public class MyJsonObject
    {
        public string id { get; set; }
        public string jsonrpc { get; set; }
        public Result result { get; set; }
    	
    	public class Result2
    	{
    		public int AccountId { get; set; }
    		public List<string> Flags { get; set; }
    		public int PartnerId { get; set; }
    		public Dictionary<string,string> Settings { get; set; } //or List<KeyValuePair<string,string>>
    	}
    	
    	public class Result
    	{
    		public List<Result2> result { get; set; }
    		public object totalStatistics { get; set; }
    	}
    }
