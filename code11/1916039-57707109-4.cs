    async void Button1_Click(object sender, EventArgs e)
    {
        var handler = SomeEvent;
        if (handler == null)
            return;
        Text = "Waiting for event to be handled.";
        button1.Enabled = false;
        using (var sem = new SemaphoreSlim(0, 1))
        {
            var args = new MyEventArgs(sem);
            handler(this, args);
            await sem.WaitAsync();
        }
        Text = "Finished waiting for event to be handled.";
        button1.Enabled = true;
    }
