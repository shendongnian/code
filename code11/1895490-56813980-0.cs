    public static List<IGrouping<object, T>> SortOrder<T>(List<IGrouping<object, T>> list, string sortOrder) where T : new()
    {
        Type listType = AssemblyHelper.GetCollectionType(list);
        if (listType.Name.Contains("IGrouping"))
        {
            var t = list.SelectMany(x => x);
            Type tType = AssemblyHelper.GetCollectionType(t);
            foreach (var prop in tType.GetProperties())
            {
                if (prop.Name.ToLower() == Value)
                {
                    if (sortOrder.Contains("_"))
                    {
                        sortOrder = Value + sortOrder.Substring(sortOrder.IndexOf("_"));
                    }
                    else
                    {
                        sortOrder = Value;
                    }
                }
                if (prop.Name.ToLower() == sortOrder)
                {
                    return t.OrderBy(x => prop.GetValue(x, null)).GroupBy(x => prop.GetValue(x, null)).ToList();
                }
                else if (prop.Name.ToLower() + Sort.Desc == sortOrder)
                {
                    return t.OrderByDescending(x => prop.GetValue(x, null)).GroupBy(x => prop.GetValue(x, null)).ToList();
                }
            }
        }
        return default(List<IGrouping<object, T>>);
    }
