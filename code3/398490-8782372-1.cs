    void Main()
    {
    	string File1 = @"104500 1 
    104501 1 
    ";
    	 
    	string File2 = 
    @"104500 2 
    104501 2
    104501 4
    "; 
    
    	string File3 = 
    @"104500 5 
    104501 5
    "; 
    
    	var ds3 = ExtractData(File1, 1).Union( ExtractData(File2, 2) )
    	                               .Union( ExtractData(File3, 3))
    								   .GroupBy (d => d.Time );
    	ds3.Dump();
    	
    	
    }
    
    public static IEnumerable<DataAndTime> ExtractData(string data, int fileID)
    {
    
    	string pattern = @"^(?<Time>[^\s]+)(?:\s+)(?<Data>[^\s]+)";
    	
    	 return Regex.Matches(data, pattern, RegexOptions.Multiline)
    	               .OfType<Match>()
    				   .Select (m => new DataAndTime()
    	                               { 
    								     FileID = fileID,
    								     Time = m.Groups["Time"].Value,
    								     Data = int.Parse(m.Groups["Data"].Value)
    								}
    								   );
    
    }
    
    
    // Define other methods and classes here
    
    public class DataAndTime
    {
       public int FileID { get; set; }
    	public string Time { get; set; }
    	public int Data { get; set; }
