    public static class ListExtension
    {
               public static IOrderedEnumerable<T>  OrderByPropertyName<T>(this ICollection<T> list, string sortColumnName, string sortDirection)
        {
            var type = typeof(T);
            var property = sortColumnName == "" ? type.GetProperties().FirstOrDefault() : type.GetProperties().Where(p => p.Name == sortColumnName).FirstOrDefault();
            return sortColumnName == "asc" ? list.OrderBy(p => property.GetValue(p)) : list.OrderByDescending(p => property.GetValue(p));
        }
    }
