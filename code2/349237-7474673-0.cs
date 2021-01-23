    // look for the "ServiceBehavior" 
    ServiceBehaviorAttribute srvBehavior = host.Description.Behaviors.Find<ServiceBehaviorAttribute>();
    if (srvBehavior == null)
    {
       // if we didn't find the service behavior - create one and add it to the list of behaviors
       srvBehavior = new ServiceBehaviorAttribute();
       srvBehavior.InstanceContextMode == InstanceContextMode.PerCall;
       host.Description.Behaviors.Add(srvBehavior);
    }
    else
    {
       // if we found it - make sure the InstanceContextMode is set up properly
       srvBehavior.InstanceContextMode == InstanceContextMode.PerCall;
    }
