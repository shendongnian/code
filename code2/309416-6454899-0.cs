    public class Svc1
    {
        private Proxy proxy; 
        public void Method1(string param)
        {
            Proxy.Method1(param);
        }
    }
    
    public class Svc2
    {
        private Proxy proxy;
        public int Method2()
        {
            return Proxy.Method2();
        }
    }
    
    public class MegaProxy
    {
        public Svc1 Class1 {get; set;}
        public Svc2 Class2 {get; set;}
    }
 	
