    public class ReferenceConvention : IReferenceConvention
    {
        public void Apply(IManyToOneInstance instance)
        {
            Type instanceType = instance.Class.GetUnderlyingSystemType();
            if (instanceType = typeof(IFoo))
            {
                instance.CustomClass<Foo>();
            }
            instance.Cascade.All();
        }
    }
