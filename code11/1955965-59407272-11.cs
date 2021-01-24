    public class A
    {
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
          // Unreliable, expensive method here. 
          // Will be called more than once if it returns null / empty.
          Console.WriteLine("Called");
    	  return "Foo";
       }
    }
