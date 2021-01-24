		public partial class myUserControl : UserControl
		{
			public string test;
			public event EventHandler<UserEventArgs> SomebuttonClicked;
			public myUserControl()
			{
				InitializeComponent();
				test = "This is test";
			}
			private void UserControl1_Load(object sender, EventArgs e)
			{
			}
			private void Button1_Click(object sender, EventArgs e)
			{
				SomebuttonClicked(sender, new UserEventArgs
					{
						SomeVariable = test
					}
				);
			}
		}
		public class UserEventArgs : EventArgs
		{
			public string SomeVariable { get; set; }
		}
	
