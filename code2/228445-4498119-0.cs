    public static T BuildUp<T>()
            {
                var locator = new Locator { { typeof(ILifetimeContainer), new LifetimeContainer() } };
                 locator.Add(new DependencyResolutionLocatorKey(typeof(ISessionStateLocatorService), null), new SessionStateLocatorService());
    
                var builder = new Builder();
    
                var attribute = new CreateNewAttribute();
                IParameter parameter = attribute.CreateParameter(typeof (T));
                           
                builder.Strategies.AddNew<SessionStateBindingStrategy>(BuilderStage.PreCreation);
    
                var builderContext = 
                    new BuilderContext(builder.Strategies.MakeStrategyChain(),locator,builder.Policies);
                object value = parameter.GetValue(builderContext);
                
                return (T)value;
            }
    
         
    
         
