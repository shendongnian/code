    public CategoryAttribute(string resourceKey, Type resourceType) : this("Default")
    {
        public override string Category
        {
           get
           {
               PropertyInfo property = resourceType.GetProperty(
                             resourceKey,BindingFlags.Public|BindingFlags.Static); 
               if (property == null)
               {
                   return resourceKey;
               }
               return property.GetValue(null, null) as string;
           }
        }
    }
