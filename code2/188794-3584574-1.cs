     namespace SomeNamespace.SomeSubNamespace
     {
        class SomeClass
        {
            void WriteToFile()
            {
                using (var someFile = new StreamWriter(somePath))
                {
                    lock(someCriticalSection)
                    {
                       ExecuteCriticalSection();
                    }
                }
            }
            void ExecuteCriticalSection()
    	    {
    	        using (var someDisposableThing1 = new DisposableThing())
                {
    		    DoSomething();
    		    ExecuteFinalCriticalSection();
                }	
    	    }
    			
    	    void ExecuteFinalCriticalSection()
    	    {
    	        using (var someDisposableThing2 = new DisposableThing())
                {
    		    lock(someOtherCriticalSection)
                    {
    		        DoSomethingMore();
                    }
                }
            }
    	}
    }
