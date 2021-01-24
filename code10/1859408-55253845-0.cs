	private void btnReadRandomNumbers_Click(object sender, EventArgs e)
	{
		if (fodOpenFile.ShowDialog() == DialogResult.OK)
		{
			var lines = File.ReadAllLines(fodOpenFile.FileName);
			
			var result =
				lines
					.Select(x => int.Parse(x))
					.Aggregate(
						new { count = 0, sum = 0 },
						(a, x) => new { count = a.count + 1, sum = a.sum + x });
	
			lstRandomNumbers.Items.Clear();
			lstRandomNumbers.Items.AddRange(lines);
			lblNumberCount.Text = result.count.ToString();
			lblSumNumbers.Text = result.sum.ToString();
		}
	}
