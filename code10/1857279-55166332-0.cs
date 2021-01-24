    private async void button1_Click(object sender, EventArgs e)
    {
        button1.BackColor = Color.LimeGreen;
        await Task.Run(() =>
        {
            System.Threading.Thread.Sleep(5000);
            button1.BackColor = Color.DarkGreen;
        });
    }
