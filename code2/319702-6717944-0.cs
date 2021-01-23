    public static class TypeConverter
    {
        /// <summary>
        /// Instantiates a new DestinationType copying all public properties with the same type and name from the SourceType.
        /// The destination object must have a parameter less constructor.
        /// </summary>
        /// <param name="sourceObject">The source object.</param>
        /// <param name="destinationType">Type of the destination object.</param>
        public static DestinationType Convert<SourceType, DestinationType>(SourceType sourceObject, Type destinationType)
        {
            if (destinationType.GetConstructors().Where(x => x.GetParameters().Count() == 0).Count() == 0)
                throw new Exception("A parameter less constructor is required for the destination type.");
    
            // instantiate the destination object
            
            DestinationType destinationObject = Activator.CreateInstance<DestinationType>();
    
            // get all public properties from the source and destination object
    
            IEnumerable<PropertyInfo> sourceProps = sourceObject.GetType().GetProperties().Where(x => x.PropertyType.IsPublic);
    
            IEnumerable<PropertyInfo> destinationProps = destinationType.GetProperties().Where(x => x.PropertyType.IsPublic || x.PropertyType.IsEnum);
    
            // copy the public properties that exist in both the source type and destination type
    
            foreach (PropertyInfo prop in destinationProps)
            {
                PropertyInfo sourceProp = sourceProps.SingleOrDefault(x => x.Name == prop.Name);
    
                if (sourceProp != null)
                {
                    try
                    {
                        object propValue = new object();
                        if (prop.PropertyType.IsEnum)
                        {
                            propValue = Enum.Parse(prop.PropertyType, sourceProp.GetValue(sourceObject, null).ToString());
    
                        }
                        else
                        {
                            propValue = System.Convert.ChangeType(sourceProp.GetValue(sourceObject, null), prop.PropertyType);
                        }
    
    
                        prop.SetValue(destinationObject, propValue, null);
                    }
                    catch { }
                }
            }
    
            return destinationObject;
        }
    
        /// <summary>
        /// Instantiates a new DestinationType copying all public properties with the same type and name from the SourceType.
        /// The destination object must have a parameter less constructor.
        /// </summary>
        /// <param name="sourceObject">The collection of source objects.</param>
        /// <param name="destinationType">Type of the destination object.</param>
        public static IEnumerable<DestinationType> Convert<SourceType, DestinationType>(IEnumerable<SourceType> sourceObjects, Type destinationType)
        {
            List<DestinationType> convertedObjecs = new List<DestinationType>();
    
            List<SourceType> sourceObjectList = sourceObjects.ToList();
    
            foreach (SourceType item in sourceObjectList)
                convertedObjecs.Add(Convert<SourceType, DestinationType>(item, destinationType));
    
            return convertedObjecs;
        }
    }
