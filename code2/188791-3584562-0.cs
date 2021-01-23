    namespace SomeNamespace 
    { 
            class SomeClass {
                void SomeFunction() {
                    using (var someFile = new StreamWriter(somePath)) {
                        try {
                            lock(someCriticalSection) {
                                using (var someDisposableThing1 = new DisposableThing()) {
                                    DoSomething();                             
                                  
                                 }
                             }
                        } 
                        catch(Exception e) 
                        { 
                            Log(e); 
                        } 
                    }
                } 
            } 
        
    } 
