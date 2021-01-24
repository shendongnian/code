    internal static class Extensions
    {
    	public static bool In(this string value, params string[] args)
        {
            return args.Contains(value);
        }
    
    }
