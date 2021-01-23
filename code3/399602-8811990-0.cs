    // C# method names cannot contain character ,
    public double[] Parse(string param)
    {
    	string[] res = param.Split(new string[] { "x",  "y" }, StringSplitOptions.RemoveEmptyEntries);
    	
    	double x = double.Parse(res[0]);
    	double y = double.Parse(res[1]);
    
    	//get the values back as array
    	return new double[] { x, y };
    }
