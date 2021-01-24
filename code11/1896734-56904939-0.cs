    public class MyDeserializer
    {
        public static TEntity PopulateObject<TEntity>(string[] jsonStrings)
        {
            TEntity entity = default(TEntity);
            if (jsonStrings != null && jsonStrings.Length > 0)
            {
                for (int i = 0; i < jsonStrings.Length; i++)
                {
                    entity = JsonSerializer.Parse<TEntity>(jsonStrings[i]);
                }
            }
            return entity;
        }
    }
