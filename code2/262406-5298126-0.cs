     string line = "";
    using (StreamReader sr = File.OpenText("PathToFile"))
    {
    	while ((line = sr.ReadLine()) != null)
    	{
    	    if (line.Trim() != "")
    	    {
    		 string[] tokens = line.Split(new char[] { ' ' });
    		 //Process the tokens
    	    }
    	}
    }
