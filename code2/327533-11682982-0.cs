    public static void ReadAllDateTimeValuesAsUtc(this DbContext context)
    {
            ((IObjectContextAdapter)context).ObjectContext.ObjectMaterialized += ReadAllDateTimeValuesAsUtc;
    }
    
    private static void ReadAllDateTimeValuesAsUtc(object sender, ObjectMaterializedEventArgs e)
    {
        //Extract all DateTime properties of the object type
        var properties = e.Entity.GetType().GetProperties()
            .Where(property => property.PropertyType == typeof (DateTime) ||
                               property.PropertyType == typeof (DateTime?)).ToList();
        //Set all DaetTimeKinds to Utc
        properties.ForEach(property => SpecifyUtcKind(property, e.Entity));
    }
    
    private static void SpecifyUtcKind(PropertyInfo property, object value)
    {
        //Get the datetime value
        var datetime = property.GetValue(value, null);
            
        //set DateTimeKind to Utc
        if (property.PropertyType == typeof(DateTime))
        {
            datetime = DateTime.SpecifyKind((DateTime) datetime, DateTimeKind.Utc);
        }
        else if(property.PropertyType == typeof(DateTime?))
        {
            var nullable = (DateTime?) datetime;
            if(!nullable.HasValue) return;
            datetime = (DateTime?)DateTime.SpecifyKind(nullable.Value, DateTimeKind.Utc);
        }
        else
        {
            return;
        }
    
        //And set the Utc DateTime value
        property.SetValue(value, datetime, null);
    }
