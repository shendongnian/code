    using System;
    using System.Web.Mvc;
    using System.Web.Routing;
    
    namespace SystemWebMvcTest
    {
        // See here: I've declared a type with the same name as a type
        // from the System.Web.Mvc namespace in System.Web.Mvc.dll.
        public interface IController
        {
        }
        public class IoCControllerFactory : DefaultControllerFactory
        {
            // Now this method signature, since it does not include the fullly
            // qualified name of its return type, is actually defined to return
            // an instance of the IController interface defined in THIS assembly,
            // rather than the System.Web.Mcv.IController interface.
            protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
            {
                return null;
            }
        }
    }
