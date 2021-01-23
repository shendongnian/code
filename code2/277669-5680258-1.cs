    public class Wgs84GeographyTypeConvention : IPropertyConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            if (typeof(IGeometry).IsAssignableFrom(instance.Property.PropertyType))
            {
                instance.CustomType(typeof(Wgs84GeographyType));
                instance.CustomSqlType("GEOGRAPHY");
            }
        }
    }
