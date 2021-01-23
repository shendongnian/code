        using (StreamReader reader = new StreamReader("file.txt"))
    	{
    	    string line;
    	    while ((line = reader.ReadLine()) != null)
    	    {
                    for(int i = 0; i < line.Length;  i++){
                         //do something with  line[i]  
                    }
    		
    	    }
    	}
