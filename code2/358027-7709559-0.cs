	public class Program
	{
		public void Main()
		{
			var button = new Button();
			button.Click += button_Click;
		}
	
		void button_Click(object sender, EventArgs e)
		{
			var button = (Button)sender; //Need to cast here
		}
	}
