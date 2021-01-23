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
            TProperty newValue = converter.Invoke(item); 
            if(value == null)
            {
                if(newValue != null)
                {
                    return false;
                } 
   
                continue;
            }
    
            if (!value.Equals(newValue))
            {
                return false;
            }
        }
    
        return true;
    }
