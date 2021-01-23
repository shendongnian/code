    ServiceHost host = new ServiceHost();
    ServiceBehaviorAttribute sba = host .Description.Behaviors.Find<ServiceBehaviorAttribute>();
                if (sba == null)
                {
                    sba = new ServiceBehaviorAttribute();
                    sba.MaxItemsInObjectGraph = int.MaxValue;
                    host.Description.Behaviors.Add(sba);
    }
