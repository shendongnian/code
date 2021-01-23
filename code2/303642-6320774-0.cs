    private void Form1_Load(object sender, EventArgs e)
    {
        var bw = new BackgroundWorker();
        bw.DoWork += DoWork;
        bw.RunWorkerAsync();
    }
    private void DoWork(object sender, DoWorkEventArgs e)
    {
        var itemList = new List<int> {1, 22, 3, 4};
        var func = new Action<int>(itemToAdd => listBox1.Items.Add(itemToAdd));
        foreach (var item in itemList)
        {
            listBox1.Invoke(func, item);
        }
    }
