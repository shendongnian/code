    public static class MongodbExtentions
    {
        public static T FindOne<T>(this MongoCollection collection, 
                                   params string[] excludedFields)
        {
            return collection.FindAllAs<T>().SetLimit(1)
                                            .SetFields(excludedFields)
                                            .FirstOrDefault();
        }
    }
