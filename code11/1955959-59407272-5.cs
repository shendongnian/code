    public class A
    {
       // Provide a factory
       private string _cachedString = null;
       private object _syncLock = new object();
    
       public string GetStr()
       {
          if (_cachedString == null)
    	  {
    		  lock(_syncLock)
    		  {
    		      if (_cachedString == null)
    			  {
    			      var test = CalculateStr();
    				  if (!string.IsNullOrEmpty(test))
    				  {
    				      _cachedString = test;
    				  }
                      return test;
    			  }
    		  }
    	  }
    	  return _cachedString;
       }
       
       public string CalculateStr()
       {
          Console.WriteLine("Called");
    	  return "Foo";
       }
    }
