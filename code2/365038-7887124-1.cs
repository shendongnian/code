	public class MyForm
	{
		public event Action<bool> CheckBoxChanged;
		private CheckBox testchbox = new CheckBox();
		private void Form1_Load(object sender, EventArgs e)
		{
			testchbox.CheckedChanged += (s, e) =>
			{
				var cbc = this.CheckBoxChanged;
				if (cbc != null)
				{
					cbc(testchbox.Checked);
				}
			};
		}
	}
