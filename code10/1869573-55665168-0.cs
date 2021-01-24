private void button1_Click(object sender, EventArgs e)
{
    var worker = new BackgroundWorker();
    worker.DoWork += (_, __) =>
    {
        // do your hack here...
    };
    worker.RunWorkerCompleted += (_, __) =>
    {
        MessageBox.Show("Finito!");
    };
    worker.RunWorkerAsync();
}
or
private async void button1_Click(object sender, EventArgs e)
{
    await Task.Run(() =>
    {
        Thread.Sleep(1000);
    });
    MessageBox.Show("Finito!");
}
