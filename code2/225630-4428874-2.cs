    public class ReferenceConvention : IReferenceConvention
    {
        public void Apply(IManyToOneInstance instance)
        {
            Type instanceType = instance.Class.GetUnderlyingSystemType();
            
            if (instanceType.IsInterface)
            {
                // Assuming that the type starts with an I get the name of the concrete class
                string className = instanceType.Name.Substring( 1 );
                instance.CustomClass(instanceType.Assembly.GetType(
                    instanceType.FullName.Replace( instanceType.Name, className )));
            }
            instance.Cascade.All();
        }
    }
