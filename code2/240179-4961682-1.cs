    protected override IController GetControllerInstance (RequestContext requestContext, Type controllerType)
        {
            ObjectTypeUtility.ArgumentIsNull(controllerType, "controllerType", true);
             if (!typeof(IController).IsAssignableFrom(controllerType))
                 throw new ArgumentException(string.Format(
                           "Type requested is not a controller: {0}",
                           controllerType.Name), 
                            "controllerType");    
        
                IController controller = IoCWorker.Resolve(controllerType) 
                                          as IController;                
                return controller;
        
        }
