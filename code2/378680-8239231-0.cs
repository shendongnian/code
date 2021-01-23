    private int _ticks;
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        timer1.Start();
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        if (_ticks++ == 4)
        {
            //Call correction method
            timer1.Stop();
            _ticks = 0;
        }
    }
