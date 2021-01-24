    while (!inputFile.EndOfStream)
    {
    	line = inputFile.ReadLine();
    
    	string[] tokens = line.Split(delim);
    
    	DateTime.TryParse(tokens[0], out entry.date);
    	int.TryParse(tokens[1], out entry.precipitation);
    	int.TryParse(tokens[2], out entry.hightemp);
    	int.TryParse(tokens[3], out entry.lowtemp);
    
    	weatherList.Add(entry);
    }
