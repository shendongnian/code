    internal static void SetCollectionProperty(object resource, string propertyName,
        IEdmCollectionTypeReference edmPropertyType, object value, bool clearCollection)
    {
        if (value != null)
        {
            IEnumerable collection = value as IEnumerable;
            Contract.Assert(collection != null,
                "SetCollectionProperty is always passed the result of ODataFeedDeserializer or ODataCollectionDeserializer");
            Type resourceType = resource.GetType();
            Type propertyType = GetPropertyType(resource, propertyName);
            Type elementType;
            if (!TypeHelper.IsCollection(propertyType, out elementType))
            {
                string message = Error.Format(SRResources.PropertyIsNotCollection, propertyType.FullName, propertyName, resourceType.FullName);
                throw new SerializationException(message);
            }
            IEnumerable newCollection;
            if (CanSetProperty(resource, propertyName) &&
                CollectionDeserializationHelpers.TryCreateInstance(propertyType, edmPropertyType, elementType, out newCollection))
            {
                // settable collections
                collection.AddToCollection(newCollection, elementType, resourceType, propertyName, propertyType);
                if (propertyType.IsArray)
                {
                    newCollection = CollectionDeserializationHelpers.ToArray(newCollection, elementType);
                }
                SetProperty(resource, propertyName, newCollection);
            }
            else
            {
                // get-only collections.
                newCollection = GetProperty(resource, propertyName) as IEnumerable;
                if (newCollection == null)
                {
                    string message = Error.Format(SRResources.CannotAddToNullCollection, propertyName, resourceType.FullName);
                    throw new SerializationException(message);
                }
                if (clearCollection)
                {
                    newCollection.Clear(propertyName, resourceType);
                }
                collection.AddToCollection(newCollection, elementType, resourceType, propertyName, propertyType);
            }
        }
    }
