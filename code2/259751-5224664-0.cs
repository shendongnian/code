    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    class SomeSvc : ContractInterface
    {
        private readonly Object _syncLock = new Object();
        // this method is ConcurrencyMode.Single
        public String SingleMethod1()
        {
             lock (_syncLock)
             {
                 // method code here
             }
        }
        // this method is ConcurrencyMode.Single
        public String SingleMethod2()
        {
             lock (_syncLock)
             {
                 // method code here
             }
        }
        // this method is ConcurrencyMode.Multiple
        public String MultipleMethod()
        {
            // ...
        }
     }
