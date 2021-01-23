    class Test
    	{
    		static object ImARoot = new object(); //static objects/static fields
    		
    		void foo(object paramRoot) // parameters  I'm a root to but only when in foo
    		{
    			object ImARoot2 = new object(); //local objects but only when I'm in foo. 
    
    			//I'm a root after foo ends but only because GC.SuppressFinalize is not called called (typically in Dispose)
    			SomethingWithAFinalizer finalizedRoot = new SomethingWithAFinalizer (); 
    	
    		
    		}
    	}
