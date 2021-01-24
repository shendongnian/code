	OpenFileDialog openFile = new OpenFileDialog();
	private void btnLoadFile_Click(object sender, EventArgs e)
	{
		if (openFile.ShowDialog() == DialogResult.OK )
		{
			try
			{
				List<String> lines = new List<String>(System.IO.File.ReadAllLines(openFile.FileName));
				lines.RemoveAll(l => l.Trim().Length == 0);
				if (lines.Count > 0)
				{
					listBox1.Items.Clear();
					listBox1.Items.AddRange(lines.ToArray());
				}                    
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error Loading File");
			}                
		}
	}
	private void btnFirst_Click(object sender, EventArgs e)
	{
		if (listBox1.Items.Count > 0)
		{
			listBox1.SelectedIndex = 0;
		}
	}
	private void btnLast_Click(object sender, EventArgs e)
	{
		if (listBox1.Items.Count > 0)
		{
			listBox1.SelectedIndex = (listBox1.Items.Count - 1);
		}
	}
	private void btnPrevious_Click(object sender, EventArgs e)
	{
		if (listBox1.Items.Count > 0)
		{
			listBox1.SelectedIndex = (listBox1.SelectedIndex > 0) ? (listBox1.SelectedIndex - 1) : 0;
		}
	}
	private void btnNext_Click(object sender, EventArgs e)
	{
		if (listBox1.Items.Count > 0)
		{
			listBox1.SelectedIndex = (listBox1.SelectedIndex < (listBox1.Items.Count - 1)) ? (listBox1.SelectedIndex + 1) : (listBox1.Items.Count - 1);
		}
	}
