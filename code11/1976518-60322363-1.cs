    private async void button1_Click(object sender, EventArgs e)
    {
        richTextBox1.Text = string.Empty;
        foreach (char c in "hello world")
        {
            richTextBox1.Text += c;
            await Task.Delay(100);
        }
    }
