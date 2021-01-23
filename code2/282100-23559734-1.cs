    private static string GetCSharpString(this object o)
    {
        if (o is String)
        {
            return string.Format("\"{0}\"", o);
        }
        if (o is Int32)
        {
            return string.Format("{0}", o);
        }
        if (o is Decimal)
        {
            return string.Format("{0}m", o);
        }
        if (o is DateTime)
        {
            return string.Format("DateTime.Parse(\"{0}\")", o);
        }
        if (o is IEnumerable)
        {
            return String.Format("new {0} {{ {1}}}", o.GetClassName(), ((IEnumerable)o).GetItems());
        }
        
        return string.Format("{0}", o.CreateObject());
    }
    private static string GetItems(this IEnumerable items)
    {
        return items.Cast<object>().Aggregate(string.Empty, (current, item) => current + String.Format("{0}, ", item.GetCSharpString()));
    }
