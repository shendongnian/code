    async void button1_Click(object sender, EventArgs e)
    {
        this.Text = "[button1_Click] About to await Task.Delay(5000)";
        await Task.Delay(5000);
        this.Text = "[button1_Click] Awaited Task.Delay(5000)";
    }
    void button2_Click(object sender, EventArgs e)
    {
        this.Text = "[button2_Click] About to start task to Thread.Sleep(5000)";
        Task.Run(() =>
        {
            Thread.Sleep(5000);
        }).ContinueWith(_ =>
        {
            this.Invoke(new Action(() =>
            {
                this.Text = "[button2_Click] Task to Thread.Sleep(5000) returned.";
            }));
        });
    }
    void button3_Click(object sender, EventArgs e)
    {
        this.Text = "[button3_Click] About to call Thread.Sleep(5000)";
        Thread.Sleep(5000);
        this.Text = "[button3_Click] Called Thread.Sleep(5000)";
    }
