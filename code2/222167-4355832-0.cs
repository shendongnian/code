    <%@ ServiceHost 
        Language = "C#" 
        Debug = "true" 
        Factory="Hello.CustomServiceHostFactory" 
        Service = "Hello.HelloService" %>
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Activation;
    namespace Hello
    {
        public class CustomServiceHostFactory : ServiceHostFactory
        {
	   public override System.ServiceModel.ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
	   {
	       return base.CreateServiceHost(constructorString, baseAddresses);
	   }
           protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
           {
	       CustomHost host = new CustomHost(serviceType, baseAddresses);
               //configure customServiceHost here
	 	   host.AddServiceEndpoint(typeof(IHelloService), new BasicHttpBinding(), "");
                   
	    	   var smb = host.Description.Behaviors.Find <System.ServiceModel.Description.ServiceMetadataBehavior>(); 
	           if(smb == null)
	           {
		       // add the "get metadata" behavior 
		       // This will allow the service to emit WSDL when tickled at the right HTTP endpoint
		       smb= new System.ServiceModel.Description.ServiceMetadataBehavior();
		       smb.HttpGetEnabled = true;
		       host.Description.Behaviors.Add(smb);
	           }	
                   return host;
           }
        }
    public class CustomHost : ServiceHost
    {
      public CustomHost()
      {
      }
      public CustomHost(Type serviceType, params Uri[] baseAddresses)
	    : base(serviceType, baseAddresses)
      {
      }
      public CustomHost(object singeltonInstance, params Uri[] baseAddresses)
            : base(singeltonInstance, baseAddresses)
	{
	} 
      protected override void ApplyConfiguration()
      {
         base.ApplyConfiguration();
      }
    }
    [ServiceContract(Namespace="http://www.example.com")]
    public interface IHelloService
    {
    [OperationContract]
       string Hello();
    }
    public class HelloService : IHelloService
    {
       public string Hello() {
            return "Hello";
       }
    }
    }
