    public static bool AllSameByProperty<TItem, TProperty>(IEnumerable<TItem> items, Converter<TItem, TProperty> converter)
    {
        TProperty value = default(TProperty);
        bool first = true;
        foreach (TItem item in items)
        {
            if (first)
            {
                value = converter.Invoke(item);
                first = false;
                continue;
            }
    
            if (!value.Equals(converter.Invoke(item)))
            {
                return false;
            }
        }
    
        return true;
    }
