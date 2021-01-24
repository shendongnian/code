    int value = 4;
    private void Form1_Load(object sender, EventArgs e)
    {
        // ...
        timer1.Interval = 1000; // Perform operation every second
    }
    private void button1_Click(object sender, EventArgs e)
    {
        timer1.Enabled = true;
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        progressBar1.Invoke(new Action(() => { progressBar1.Value = value--; }));
        if (value < 0)
        {
            timer1.Enabled = false;
        }
    }
