    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple=false, Inherited=true)]
    public abstract class GetConnectionAttribute : Attribute
    {
        public abstract IPropertySet GetConnection();
    }
    public class GetConnectionFromPropertySetAttribute : GetConnectionAttribute
    {
        public override IPropertySet GetConnection()
        {
            return new PropertySetClass();
        }
    }
    
    [GetConnectionFromPropertySet]
    public class Test
    {
    }
