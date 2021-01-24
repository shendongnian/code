    public class A {
        List<B> _list = new List<B>();
        private readonly ILogger logger;
        private readonly Func<B1> factory1;
        private readonly Func<B2> factory2;
    
        public A(ILogger logger, Func<B1> factory1, Func<B2> factory2) {  
            //Depency Injection using Autofac
            this.logger = logger;
            this.factory1 = factory1;
            this.factory2 = factory2;
       }
    
       public Add(object X) {
            if (X is String)
               _list.Add(factory1());
            else
               _list.Add(factory2());
       }
    }
