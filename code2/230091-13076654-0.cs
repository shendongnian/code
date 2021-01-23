	public static class WatiNExtensions
	{
		public static void FastType(this TextField textField, string text)
		{
			textField.SetAttributeValue("value", text);
		}
	}
