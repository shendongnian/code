    class BiDirectionalHasManyConvention : IReferenceConvention, IHasManyConvention
    {
        public void Apply(IOneToManyCollectionInstance instance)
        {
            // looks for a Property which references the type containing the collection
            var referenceProperty = instance.ChildType.GetProperties()
                .First(prop => prop.PropertyType == instance.EntityType);
            instance.Key.Column(referenceProperty.Name + "Id");
        }
        // Optional, just to make sure the foreignkey column is propertyname + "Id"
        public void Apply(IManyToOneInstance instance)
        {
            instance.Column(instance.Name + "Id");
        }
    }
