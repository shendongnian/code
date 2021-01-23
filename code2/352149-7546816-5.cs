    private void button1_Click(object sender, EventArgs e)
    {
        ThreadPool.QueueUserWorkItem((obj) =>
        {
            var lines = File.ReadLines(@"D:\test.txt");
            var count = lines.Count();
    
            Parallel.For(0, count, i =>
            {
                // some parse work
                Invoke(new Action(() =>
                {
                    progressBar1.Value = (i * 100) / count;
                }));
            });
        });
    }
