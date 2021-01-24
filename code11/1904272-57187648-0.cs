    public void BeginContact(List<InteractionController> controllers) 
    {
        foreach (var controller in controllers) 
        {
            _contactingControllers.Add(controller);
            OnPerControllerContactBegin(controller);
        }
        if (_contactingControllers.Count == controllers.Count) 
        {
            OnContactBegin();
        }
    }
    
