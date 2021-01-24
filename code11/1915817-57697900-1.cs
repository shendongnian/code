    class Class2
    {
        public List<System.Action> callbacks = new List<System.Action>();
       
        void DoStuff()
        {
            callbacks.Add(() => print("a"));
            new Class1().StartAsyncOperation(() => {
                forach(var a in callbacks()
                {
                    a();
                }
            });
        }
    
        {
            // ... much later in another place but still before StartAsyncOperation ends
            callbacks.Add(() => print ("b"));
        }
    }
