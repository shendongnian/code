            private static Func<IDataReader, object> GetDeserializer(Type type, IDataReader reader, int startBound, int length, bool returnNullIfFirstMissing)
            {
    ...
                if (!(typeMap.ContainsKey(type) || type.IsEnum /* workaround! */ || type.FullName == LinqBinary))
                {
                    return GetTypeDeserializer(type, reader, startBound, length, returnNullIfFirstMissing);
                }
                return GetStructDeserializer(type, startBound);
    
            }
