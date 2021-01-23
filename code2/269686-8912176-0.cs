    	    var stackFrames = new StackTrace().GetFrames();
            if(stackFrames==null) return null;
            var executingAssembly = Assembly.GetExecutingAssembly();
            foreach (var frame in stackFrames)
            {
                var assembly = frame.GetMethod().DeclaringType.Assembly;
                if (assembly != executingAssembly)
                {
                    return assembly;
                }
            }
	        return null;
