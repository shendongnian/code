    public static string SmartJoin(this List<string> items, string lastSeparator)
    {
        string values = "";
        if (items.Count > 1)
        {
        	values = String.Format("{0} {1} {2}",
        	            String.Join(", ", items.Take(items.Count - 1)),
        	            lastSeparator,
        	            items.Last());
        }
        else
        {
        	values = items[0].ToString();
        }
        return values;
    }
