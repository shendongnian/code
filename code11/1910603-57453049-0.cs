		public partial class myUserControl  : UserControl
		{
			public string test;
			public myUserControl ()
			{
				InitializeComponent();
				test = "This is test";
			}    
			private void Button1_Click(object sender, EventArgs e)
			{
				MessageBox.Show(test);
			}
		}
