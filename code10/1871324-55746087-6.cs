    public class ParsedFilename
    {
    	public ParsedFilename(string filename)
    	{
    		FullName = filename;
    		if (filename.Length >= 12 &&
                DateTime.TryParse(filename.Substring(0, 10), out var date))
    		{
    			Date = date;
    			Name = filename.Substring(11);
    		}
    		else
    		{
    			Date = null;
    			Name = filename;
    		}
    	}
    
    	public DateTime? Date { get; }
    	public string Name { get; }
    	public string FullName { get; }
    }
