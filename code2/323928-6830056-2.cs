    public static class DataPager
        {
            public static IEnumerable<T> PageData<T>(this IEnumerable<T> source, int currentPage, int pageSize)
            {
                var sourceCopy = source.ToList();
    
                if (sourceCopy.Count() < pageSize)
                {
                    return sourceCopy;
                }
    
                return sourceCopy.Skip((currentPage - 1) * pageSize).Take(pageSize);
            }
        }
