	class Callout : Callout.IFont
	{
		public interface IFont
		{
			int Size { get; set; }
		}
		protected int _fontSize = 0;
		int IFont.Size
		{
			get
			{
				return _fontSize;	
			}
			set
			{
				_fontSize = value;
			}
		}
		public IFont Font => this;
	}
	var callout = new Callout();
	callout.Font.Size = 100;
