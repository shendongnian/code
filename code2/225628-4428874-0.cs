    public class ReferenceConvention : IReferenceConvention
    {
        public void Apply(IManyToOneInstance instance)
        {
            Type instanceType = instance.Class.GetUnderlyingSystemType();
            
            if (instanceType.IsInterface)
            {
                string className = instanceType.Name.Substring( 1 );
                instance.CustomClass(instanceType.Assembly.GetType(instanceType.FullName.Replace( instanceType.Name, className )));
            }
            instance.Cascade.All();
        }
    }
