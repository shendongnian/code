    	private void Form1_Load(object sender, EventArgs e)
		{
			string[] files = System.IO.Directory.GetFiles(@"C:\Testing");
			this.comboBox1.Items.AddRange(files);
		}
