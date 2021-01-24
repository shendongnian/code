    private void TextBox1_MouseEnter(object sender, MouseEventArgs e)
    {
        t.Start();
    }
    
    private void TextBox1_MouseLeave(object sender, MouseEventArgs e)
    {
        t.Stop();
        Popup1.IsOpen = false;
    }
