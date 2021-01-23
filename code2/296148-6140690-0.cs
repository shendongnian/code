    public class AClass
	{
		private int index = 0;
		private string[] values = new string[] { "a", "b", "c" };
		public void Load()
		{
			string currentValue = this.values[this.index];
		}
		private void Increment()
		{
			this.index++;
			if (this.index > values.Length - 1)
				this.index = 0;
		}
		private void button1_Click(object sender, EventArgs e)
		{
			Increment();
		}
	}
