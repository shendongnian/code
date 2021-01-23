    public class IoCControllerFactory : DefaultControllerFactory   
    {  
        protected override IController GetControllerInstance(Type controllerType)  
        {
            return (Controller)ObjectFactory.GetInstance(controllerType);  
        }  
    }  
