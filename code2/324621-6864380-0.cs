    void calculateXAndYPlacement()
    {
        // Read data from file
    	var path = @"C:\Users\feldman\Documents\";
    	var data = File.ReadLines(path + "data.txt");
    	
        // Parse the values you'll be modifying your data by
        var doubleXValue = double.Parse(xDisplacementTextBox.Text);
        var doubleYValue = double.Parse(yDisplacementTextBox.Text);  					
        // apply your transformation to all valid lines of data
        var modifiedData = from line in data
	                   where LineIsValid( line )
                           select ModifyLine( line, doubleXValue, doubleYValue );
        // Do what you wish with the data
        foreach( var dataPoint in modifiedData )
        {
             // grab the values from the Tuple and put them into the
             // appropriate text boxes.
        }
    }
    
    Tuple<string,double,double> ModifyLine(string data, double xValue, double yValue)
    {
    	// split line into parts
    	var columns = Regex.Split(data, @"\s+");
    	columns.Dump();
    	// do your math on each part, I just assigned the new values
    	// for the sake of the example.
    	columns[3] = xValue.ToString();
    	columns[4] = yValue.ToString();
    	
    	// recombine the line
    	return Tuple.Create( string.Join(" ", columns), xValue, yValue );
    }
    
    bool LineIsValid(string lineData)
    {
    	return Regex.IsMatch(lineData, @"(?<x>-?\d+\.\d+)\s+(?<y>-?\d+\.\d+)");
    }
