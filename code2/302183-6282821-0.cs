    void Main()
    {
    	var client = new System.Net.WebClient();
    	client.OpenReadCompleted += (sender, e) =>
    	{
    		"Read successfully".Dump();
    	};
    	client.OpenReadAsync(new Uri("http://www.google.it"));
    	Console.ReadLine();
    }
