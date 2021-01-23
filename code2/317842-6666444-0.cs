    class Program
    {
        static void Main()
        {
	    Dictionary<string, bool> d = new Dictionary<string, bool>();
   	    d.Add("cat", true);
  	    d.Add("dog", false);
	    d.Add("sprout", true);
	    // A.
	   // We could use ContainsKey.
	    if (d.ContainsKey("dog"))
	    {
	        // Will be 'False'
	        bool result = d["dog"];
	        Console.WriteLine(result);
	    }
	    // B.
	    // Or we could use TryGetValue.
	    bool value;
	    if (d.TryGetValue("dog", out value))
	    {
	        // Will be 'False'
	        bool result = value;
	        Console.WriteLine(result);
	    }
        }
    }
