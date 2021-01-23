    public class GetDetails<T>
    {       
        public T Get (T instance, Action<T, IDataReader> mappingMethod)
        {
            //Get IDs and Add to list
            _db.ExecuteReader(storedProcedure.ToString(), CommandType.StoredProcedure, reader =>
            {
                while ( reader.Read() )
                {
                    mappingMethod(instance, reader);
                }
    
            }, parameterList.ToArray());
    
            return instance;
        }
    }
