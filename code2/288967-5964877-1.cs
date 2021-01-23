    public static string ConvertToString(this IEnumerable list)
    {
        StringBuilder sb = new StringBuilder();
        foreach (object item in list)
        {
            sb.Append(item.ToString());
        }
        return sb.ToString();
    }
Then you could check if o is an IEnumerable:
    object o = new List<int>() { 1, 2, 3, 4, 5 };
    
    if (o is IEnumerable)
    {
        string value = ((IEnumerable) o).ConvertToString();
    }
