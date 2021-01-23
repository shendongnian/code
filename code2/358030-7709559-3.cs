	public class Program
	{
		public void Main()
		{
			var button = new Button();
			button.Click += (sender, e) =>
			{
				//Can use `button` here
				//Just ignore `sender`
			};
		}
	}
