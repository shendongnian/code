    public string DictToString(IDictionary<string, object> items, string format)
    {
        format = String.IsNullOrEmpty(format) ? "{0}='{1}' " : format; 
 
        StringBuilder itemString = new StringBuilder();
        foreach(var item in items)
            itemString.AppendFormat(format, item.Key, item.Value);
 
        return itemString.ToString(); 
    }
