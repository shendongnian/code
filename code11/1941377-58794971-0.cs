    List<Color> color = new List<Color> { Color.Blue, Color.Green, Color.Red, Color.Yellow };
    private System.Timers.Timer myTimer;
    int index = 0;
    private void Form1_Load(object sender, EventArgs e)
    {
        this.myTimer = new System.Timers.Timer(500);
        this.myTimer.Elapsed += new System.Timers.ElapsedEventHandler(myTimer_Elapsed);
        this.myTimer.Enabled = true;
        this.myTimer.Start();
    }
    private void myTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
        // Set backcolor
        label1.BackColor = color[index];
        index++;
        // Check the index if out of range
        if (index >= color.Count)
        {
            myTimer.Stop();
        }
    }
