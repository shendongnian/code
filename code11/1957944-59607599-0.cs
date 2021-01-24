	protected void Button1_Click(object sender, EventArgs e)
	{
		Label1.Text = string.Empty;
		string path = @"D:\Temp\SecurityTest";
		var directories = Directory.GetDirectories(path);
		for (int i = 0; i < directories.Length; i++)
		{
			string fileName = Path.GetFileName(directories[i]);
			Label1.Text += fileName + "<br />";
		}
	}
