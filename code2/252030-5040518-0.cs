	public class MyClass
	{
	    public String varA{ get; set; }
		public String[] varB{ get; set; }			
	}
	
	public static class MyExtensions {
		public static string ToHtml(this string input, string format)
		{
			return string.Format(format, input);
		}
		
		public static string ToHtml(this string input)
		{
			return ToHtml(input,"<p>{0}</p>");
		}
		
		public static string ToHtml(this IEnumerable<string> input, string wrapperformat, string elementformat)
		{
			string body= input
							.Select(s => string.Format(elementformat,s))
				            .Aggregate((a,b)=> a+b);
			return string.Format(wrapperformat,body);
		}
		
		public static string ToHtml(this IEnumerable<string> input)
		{
			return ToHtml(input,"<ul>{0}</ul>","<li>{0}</li>");			
		}
	}
