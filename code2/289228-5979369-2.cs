    public class UniqueReferenceConvention : IReferenceConvention
    {
        public void Apply(IManyToOneInstance instance)
        {
            var p = instance.Property.MemberInfo;
            
            if (Attribute.IsDefined(p, typeof(UniqueAttribute)))
            {
                var attribute = (UniqueAttribute[])p.GetCustomAttributes(typeof(UniqueAttribute), true);
                instance.UniqueKey(attribute[0].GetKey());
            }
        }
    }
