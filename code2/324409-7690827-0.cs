    private static Assembly MyResolveEventHandler(object sender, ResolveEventArgs args)
	    {
	        if(args.Name.StartsWith("ProjectForX,")) {
		        return typeof(X).Assembly;
	        } else if(args.Name.StartsWith("ProjectForY,")) {
	        	return typeof(Y).Assembly;
	        } else if(args.Name.StartsWith("ProjectForZ,")) {
	        	return typeof(Z).Assembly;
	        }
	        return null;
	    }
    
	    public static X LoadX(string filename)
        {
        	AppDomain currentDomain = AppDomain.CurrentDomain;
        	ResolveEventHandler handler = new ResolveEventHandler(MyResolveEventHandler);
        	currentDomain.AssemblyResolve += handler;
        	try {
	            Stream stream = new FileStream(@filename, FileMode.Open);
	            try {
		            BinaryFormatter deserializer = createBinaryFormatter();
		            X model = (X)deserializer.Deserialize(stream);
		            return model;
	            } finally {
					stream.Close();
	            }
        	} finally {
        		currentDomain.AssemblyResolve -= handler;
        	}
        }
