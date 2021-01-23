    public class SingleTonSample
    {
       private static SingleTonSample instance;
       public static SingleTonSample Instance
       {
            get
            {
               return instance?? new SingleTonSample();
            }
       }
    
       private SingleTonSample()
       {
        /// todo
       }
       
       public void Foo()
       {
         ///todo
       }
    }
    
    public class UseSingleton
    {
        public void Test()
        {
           SingleTonSample sample = SingleTonSample.Instance;
           sample.Foo();
        }
    }
