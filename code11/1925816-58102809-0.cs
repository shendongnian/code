    private void button1_Click(object sender, EventArgs e)
    {
      Timer.Start();
      while ( true )
        ;
    }
    private void button2_Click(object sender, EventArgs e)
    {
      Timer.Start();
      while ( true )
        Thread.Sleep(100);
    }
    private void button3_Click(object sender, EventArgs e)
    {
      Timer.Start();
      while ( true )
        Application.DoEvents();
    }
