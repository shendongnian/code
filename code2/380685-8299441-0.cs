    private void Form1_KeyUp(object sender, KeyEventArgs e)
    {
       _clear = true;       
    }
    
    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
       if (e.Modifiers == Keys.Control)
       {
          _clear = false;
       }
    }
