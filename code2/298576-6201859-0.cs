        // get specified type for reflection
        Type objectType = System.Type.GetType(_sourceType, true, true);
        // check for the types that have MetadataType attribute because 
        // it is they who have the DataAnnotations attributes
        IEnumerable<MetadataTypeAttribute> mt = objectType.GetCustomAttributes(typeof(MetadataTypeAttribute), false).OfType<MetadataTypeAttribute>();
        if (mt.Count() > 0)
        {
            objectType = mt.First().MetadataClassType;
        }
