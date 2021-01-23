    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false, Inherited = true)]
    public class WorkspaceAttribute : Attribute
    {
        public ConnectionPropertiesDelegate ConnectionDelegate { get; set; }
        public WorkspaceAttribute(Type delegateType, string delegateName)
        {
             ConnectionDelegate = (ConnectionPropertiesDelegate)Delegate.CreateDelegate(delegateType, delegateType.GetMethod(delegateName));
        }
    }
    [Workspace(typeof(TestDelegate), "GetConnection")]
    public class Test
    {
    }
 
