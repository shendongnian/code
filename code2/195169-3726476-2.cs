    public class MyServiceHost : ServiceHost
    {
        public MyType MyObject { get; private set; }
    
       public MyServiceHost(Type serviceType, Uri[] baseAddresses, MyType myObject) 
         :base(serviceType, baseAddresses)
       {
         this.MyObject = myObject;
       }
    }
