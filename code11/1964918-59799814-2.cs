cs
public static class Ext
{
	public static int IndexOf(this string thisString, string[] values)
	{
		var index = thisString.Length;
		var isFound = false;
		foreach (var item in values)
		{
			var itemIndex = thisString.IndexOf(item, StringComparison.InvariantCulture);
			if (itemIndex != -1 && itemIndex < index)
			{
				index = itemIndex;
				isFound = true;
			}
		}
		return isFound ? index : -1;
	}
}
The usage example
cs
var index = "AppleBananaCherry".IndexOf(new[] {"Banana", "Cherry"}); //returns 5
index = "AppleBananaCherry".IndexOf(new[] { "Cherry", "Banana" }); //returns 5
