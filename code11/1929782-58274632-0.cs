    string file_path = "...";
    //read the number of liens from the file
    var num_lines = File.ReadAllLines(file_path).Count();
    
    //Use StreamReader to read the file in line by line
    using (StreamReader reader = new StreamReader(file_path))
    {
    	string[,] result = new string[num_lines, 2];
    	string line;
    	char[] separator = new char[] { ',' };
    
    	//loop over the lines until the end of the file
    	for(int current_line = 0; !reader.EndOfStream; current_line++)
    	{
    		line = reader.ReadLine();
    		//second argument limits you to two parts, so additional commas will not cause issues
    		var parts = line.Trim().Split(separator, 2); 
    		//make sure the data was in your expected format (i.e. two parts)
    		if(parts.Length == 2)
    		{
    			result[current_line, 0] = parts[0];
    			result[current_line, 1] = parts[1];
    		}
    	}
    }
