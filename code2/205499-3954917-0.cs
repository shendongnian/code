    [Serializable]
    public class PropertyChangeAwareAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionEventArgs eventArgs)
        {
            if (eventArgs.Method.Name.StartsWith("set_")) 
                ((SearchBagBase)eventArgs.Instance).PropertiesChanged.Add(eventArgs.Method.Name);
            base.OnEntry(eventArgs);
        }
    }
    
            
    abstract class SearchBagBase
    {
        public List<string> PropertiesChanged = new List<String>();
    }
    
    [PropertyChangeAware]
    class RegularSearch : SearchBagBase
    {
        public String Key { get; set; }
    }
