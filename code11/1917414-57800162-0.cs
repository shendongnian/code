    _codeDomComponentSerializationService = new CodeDomComponentSerializationService(serviceContainer);
    if (_codeDomComponentSerializationService != null)
    {
      serviceContainer.RemoveService(typeof(ComponentSerializationService), false);
      serviceContainer.AddService(typeof(ComponentSerializationService), _codeDomComponentSerializationService);
    }
    
    _designerSerializationService = new 
    DesignerSerializationServiceImpl(serviceContainer);
    
    if (_designerSerializationService != null)
     { 
      serviceContainer.RemoveService(typeof(IDesignerSerializationService), false);
      serviceContainer.AddService(typeof(IDesignerSerializationService), _designerSerializationService);
    }
