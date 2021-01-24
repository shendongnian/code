	private void button1_Click(object sender, EventArgs e)
	{
		if (txb_code.Text.StartsWith("{"))
		{
			Console.WriteLine("Bracket in first position present.");
		}
		else
		{
			Console.WriteLine("Bracket in first position NOT present.");
		}
	}
