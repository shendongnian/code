	public class MyListBoxItem
	{
		public MyListBoxItem(string value, string text)
		{
			Value = value;
			Text = text;
		}
		public string Value { get; set; }
		public string Text { get; set; }
		public override string ToString()
		{
			return Text;
		}
	}
