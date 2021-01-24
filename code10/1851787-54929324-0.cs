    class MyClass
    {
        public MyClass()
        {
            
        }
        
        public async Task Method2(bool runAsync)
        {
            //async immediately
            await Task.Delay(1000); //no Thread.Sleep. Blocking code != good
        }
    }
