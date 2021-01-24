    static bool HasNullPrperties<TSource>(this TSource source)
        where TSource : class
    {
         // Take the type of the source, and get all properties of this type
         var result = source.GetType().GetProperties()
             // keep only the readable properties (so you can do GetValue)
             // and those properties that have a nullable type
             .Where(property => property.CanRead 
                 && Nullable.GetUnderlyingType(property.Type) != null)
             // for every of this properties, ask the source object for the property value:
            .Select(property => property.GetValue(source))
            // and keep only the properties that have a null value
            .Where(value => value == null);
            // return true if source has any property with a null value
            // = if there is any value left in my sequence
            .Any();
        return result;  
    }
