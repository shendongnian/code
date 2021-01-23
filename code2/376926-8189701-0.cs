	public class HotkeyViewModel
	{
		private readonly string _DisplayString;
		public string DisplayString { get { return _DisplayString; } }
		private readonly Color _Color;
		public Color Color { get { return _Color; } }
		public HotkeyViewModel(string displayString, Color color)
		{
			_DisplayString = displayString;
			_Color = color;
		}
	}
