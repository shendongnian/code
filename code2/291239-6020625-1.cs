    interface IMyServiceAdaptor {
       void SomeMethod(params );
       void SomeMethod2(params );
    }
    public class ServiceAdaptor : IMyServiceAdaptor{
        #psudo code
        ServiceProxyClient client  { get;set;}
        public void SomeMethod(parms){
           var convertedParams = Convert(parms);
           return client.SomeMethod(convertedParams );
       }
       ...etc
    }
    public class MyClient {
      [Dependancy]
      IMyServiceAgent agent { get;set;}
      public MyClient(){
         #resolve
     }
     
