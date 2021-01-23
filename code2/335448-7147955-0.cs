    public class MyUsertypeConvention : IPropertyConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            if (instance.Type.Name == "Date")
            //or
            //if (instance.Type.GetUnderlyingSystemType() == typeof(Date))
                instance.CustomType<DateTranslator>();
        }
    }
