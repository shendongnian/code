    public static class BooleanExtensions
    {
    	public static string ToYesNoString(this bool value)
    	{
    		return value ? Resources.Yes : Resources.No;
    	}
    }
