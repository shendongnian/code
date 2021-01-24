    void Main()
    {
    	List<Test> prefs = new List<Test>(){ new Test (), new Test(){PreferenceCode = 1 }};
    	
    	var res = prefs.Select(x => {
    	    if (x?.PreferenceCode == null)
    	    	Debug.Write(x);
    		return x;
    	}).Where(x => x?.PreferenceCode != null);
    	
    	res.Dump();
    }
    
    public class Test {
      public inb? PreferenceCode {get; set;}
    }
