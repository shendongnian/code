cs
public static class Ext
{
	public static int IndexOf(this string thisString, string[] values)
	{
		foreach (var item in values)
		{
			var index = thisString.IndexOf(item, StringComparison.InvariantCulture);
			if (index != -1)
				return index;
		}
		return -1;
	}
}
The usage example
cs
var index = "AppleBananaCherry".IndexOf(new[] {"Banana", "Cherry"}); //returns 5
