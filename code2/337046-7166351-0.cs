    public class EventAspectProvider : TypeLevelAspect , IAspectProvider
        {
            public IEnumerable<AspectInstance> ProvideAspects(object targetElement)
            {
                Type t = (Type)targetElement;
    
                EventInfo e = t.GetEvents().First(c => c.Name.Equals("FormClosing"));
    
                return new List<AspectInstance>() { new AspectInstance(e, new EventInter()) };
            }
    
        }
    
        [Serializable]
        public class EventInter : EventInterceptionAspect
        {
    
            public override void OnInvokeHandler(EventInterceptionArgs args)
            {
                int x = 0;
    
                if (x > 0) //Do you logic here
                {
                    args.ProceedInvokeHandler();
                }
            }
        }
