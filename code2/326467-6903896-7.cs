    internal static class JsonLinqParserFactory
    {
        internal static IJsonLinqParser<TEntity> GetParser<TEntity>()
            where TEntity : System.Data.Objects.DataClasses.EntityObject
        {
            switch (typeof(TEntity).Name)
            {
                case "BestAvailableFIP":
                    return (IJsonLinqParser<TEntity>) new JsonLinqParser_Paser();
                default:
                    //if we reach this point then we failed to find a matching type. Throw 
                    //an exception.
                    throw new Exception("Failed to find a matching JsonLinqParser in JsonLinqParserFactory.GetParser() - Unknown Type: " + typeof(TEntity).Name);
            }
        }
    }
