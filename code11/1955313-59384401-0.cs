    private void Form1_Load(object sender, EventArgs e)
    {
        progressBar1.Maximum = 5;
        progressBar1.Minimum = 0;
        progressBar1.Value = 5;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        Thread thread = new Thread(new ThreadStart((delegate
        {
            for (int i = 5; i >= 0; i--)
            {
                progressBar1.Invoke(new Action(() => { progressBar1.Value = i; }));
                Thread.Sleep(1000); // Suspend 1s
            }
        })));
    }
