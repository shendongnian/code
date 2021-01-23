		public Form1()
		{
			InitializeComponent();
			TextBox textBox = new TextBox();
			textBox.TextChanged += CheckInputText;
		}
		public void CheckInputText(object sender, EventArgs e)
		{
			// Modify text in the input control.
		}
