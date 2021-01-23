    Task t = Task.Factory.StartNew(delegate
    {
        YourForm.Invoke((Action)(() => textBox1.Text = "Enter Thread");
        for (int i = 0; i < 20; i++)
        {
            //My Long Running Work
        }
        YourForm.Invoke((Action)(() => textBox1.Text = textBox1.Text + Environment.NewLine + result);}, 
            CancellationToken.None, TaskCreationOptions.None);
