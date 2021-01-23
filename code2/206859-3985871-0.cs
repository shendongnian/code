    	public static class TimeSpanExtensions
	{
		public static string ToFriendlyString(this TimeSpan t)
		{
			return ToFriendlyString(t, Thread.CurrentThread.CurrentCulture);
		}
		public static string ToFriendlyString(this TimeSpan t, CultureInfo cultureInfo)
		{
			if(cultureInfo.IetfLanguageTag.StartsWith("en"))
			{
				return ToFriendlyString_English(t);
			}
			else
			{
				throw new NotSupportedException("This culture is currently not supported."); 
			}
		}
		private static string ToFriendlyString_English(TimeSpan t)
		{
			int years = t.Days/365;
			int months = t.Days/30;
			int weeks = t.Days/7;
			if (years > 0) 
			{
				return string.Format("{0} year{1}", years, years > 1 ? "s" : "");
			}
			if (months > 0)
			{
				return string.Format("{0} month{1}", months, months > 1 ? "s" : "");
			}
			if (weeks > 0)
			{
				return string.Format("{0} week{1}", weeks, weeks > 1 ? "s" : "");
			}
			if (t.Days > 0)
			{
				return string.Format("{0} day{1}", t.Days, t.Days > 1 ? "s" : "");
			}
			if (t.Hours > 0)
			{
				return string.Format("{0} hour{1}", t.Hours, t.Hours > 1 ? "s" : "");
			}
			if (t.Minutes > 0)
			{
				return string.Format("{0} minute{1}", t.Minutes, t.Minutes > 1 ? "s" : "");
			}
			if (t.Seconds > 0)
			{
				return string.Format("{0} second{1}", t.Seconds, t.Seconds > 1 ? "s" : "");
			}
			return "now";
		}
	}
