    private async void button2_Click(object sender, EventArgs e)
    {
        label2.Text = SynchronizationContext.Current.ToString(); //WinForms Sync Context
        await Task.Run(() =>
        {
            Thread.Sleep(2000);
            label2.Text = SynchronizationContext.Current?.ToString() ?? "Null";
            Thread.Sleep(2000);
        });
        label2.Text = "Done";
    }
