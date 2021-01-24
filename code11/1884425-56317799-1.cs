	public class MainViewModel
	{
		public TextElement[] Elements { get; } = new TextElement[]
		{
			new TextElement{ Text="Hello World! "},
			new TextElement{ Text="This is some blue text!", Foreground=Colors.Blue }
		};
	}
	public class TextElement
	{
		public string Text { get; set; }
		public Color Foreground { get; set; } = Colors.Black;
	}
