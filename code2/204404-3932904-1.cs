    public class InMemoryDataSet : List<IDataSetStorable>
    {
        public AbstractDataEntity FindEntity(string id, Type type)
        {
            // Make an instance of the passed-in type so that invoking
            // TryGetValue will throw an exception if operating on an
            // EntityList which is not of the correct type.
            var sample = type.GetConstructor(new Type[]{}).Invoke(new object[]{});
            foreach (var entityList in this)
            {
                try
                {
                    // This doesn't manage to set sample to the found entity...
                    bool idFound = (bool)entityList.GetType().GetMethod("TryGetValue").Invoke(entityList, new object[] { id, sample });
                    if (idFound)
                    {
                        // So we dig it out here with the method added to EntityList<>
                        sample = entityList.GetType().GetMethod("RetrieveEntity").Invoke(entityList, new object[] { id });
                        return (AbstractDataEntity)sample;
                    }
                }
                catch (Exception ex)
                {
                    // Likely some kind of casting exception
                }
            }
            return null;
        }
    }
