    public class WindsorControllerFactory : DefaultControllerFactory 
    { 
       private readonly IKernel kernel; 
  
       public WindsorControllerFactory(IKernel kernel) 
       { 
           this.kernel = kernel; 
       } 
  
       public override void ReleaseController(IController controller) 
       { 
           kernel.ReleaseComponent(controller); 
       } 
  
       protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType) 
       { 
           if (controllerType == null) 
           { 
               // Throw exception. Can't resolve null type.
           }
  
           return (IController)kernel.Resolve(controllerType);
       } 
    }
