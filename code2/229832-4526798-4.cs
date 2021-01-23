    textBox1.Text = "Enter Thread"; //assuming here we're on the UI thread
    Task t = Task.Factory.StartNew(delegate
    {                
        for (int i = 0; i < 20; i++)
        {
            //My Long Running Work
        }
        return result;
    })
    .ContinueWith(ret => textBox1.Text = textBox1.Text + Environment.NewLine + result, 
        TaskScheduler.FromCurrentSynchronizationContext());
