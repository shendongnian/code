    public static class QueryableExtensions
    {
        public static IQueryable<TDest> ToDTO<TSource, TDest>(this IQueryable<TSource> source)
        {
            List<TDest> destinationList = new List<TDest>();
            List<TSource> sourceList = source.ToList<TSource>();
            var sourceType = typeof(TSource);
            var destType = typeof(TDest);
            foreach (TSource sourceElement in sourceList)
            {
                TDest destElement = Activator.CreateInstance<TDest>();
                //Get all properties from the object 
                PropertyInfo[] sourceProperties = typeof(TSource).GetProperties();
                foreach (PropertyInfo sourceProperty in sourceProperties)
                {
                    //and assign value to each propery according to property name.
                    PropertyInfo destProperty = destType.GetProperty(sourceProperty.Name);
                    destProperty.SetValue(destElement, sourceProperty.GetValue(sourceElement, null), null);
                    destinationList.Add(destElement);
                }
            }
            return destinationList.AsQueryable();
        }
    }
