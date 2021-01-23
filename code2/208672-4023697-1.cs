    class Program
    {
    	public class Job
    	{
    		public string Process { get; set; }
    		public IList<string> RelatedProcesses { get; set; }
    	}
    	static void Main(string[] args)
    	{
    		var xml = "<Job>" +
    					"<Process>*something.exe</Process>" +
    						"<RelatedToProcess>*somethingelse.exe</RelatedToProcess>" +
    						"<RelatedToProcess>*OneMorething.exe</RelatedToProcess>" +
    					  "</Job>";
    		var jobXml = XDocument.Parse(xml);
    			
    		var jobs = from j in jobXml.Descendants("Job")
    					select new Job
    					{
    						Process = j.Element("Process").Value,
                            RelatedProcesses = (from r in j.Descendants("RelatedToProcess")
    										    select r.Value).ToList()
    					};
    
    		foreach (var t in jobs)
    		{
    			Console.WriteLine(t.Process);
    			foreach (var relatedProcess in t.RelatedProcesses)
    			{
    				Console.WriteLine(relatedProcess);
    			}
    		}
    
    		Console.Read();
    
    	}
    }
