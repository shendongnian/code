    void Main()
    {
    	var list = new List<CallRecord>();
    	list.Add(new CallRecord { Type="voice", From="CALLER_A", To="CALLER_B" });
    	list.Add(new CallRecord { Type="text", From="CALLER_A", To="CALLER_C" });
    	list.Add(new CallRecord { Type="voicemail", From="CALLER_A", To="CALLER_B" });
    	list.Add(new CallRecord { Type="voice", From="CALLER_A", To="CALLER_B" });
    	list.Add(new CallRecord { Type="text", From="CALLER_A", To="CALLER_C" });
    	
    	var groups = (from cr in list 
    	              group cr by new {cr.Type, cr.From, cr.To} 
    	              into g
    	              select g);
    	
    	foreach(var group in groups)
    	    Console.WriteLine("{0} - Count: {1}", group.Key, group.Count());
    }
    
    public class CallRecord
    {
    	public string Type { get; set; }
    	public string From { get; set; }
    	public string To { get; set; }
    }
