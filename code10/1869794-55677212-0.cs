	private async void button1_Click(object sender, EventArgs e)
	{
		button1.Enabled = false;
		for(int i = 1; i <=100; i++)
		{
			label1.Text = i.ToString();
			await Task.Delay(100);
			if (i % 10 == 0)
			{
				label2.Text = "Press Button2 to Continue";
				await Task.Run(() => { 
					mre.WaitOne();
				});
				label2.Text = "";
			}
		}
		button1.Enabled = true;
	}
