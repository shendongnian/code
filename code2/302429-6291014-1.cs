    textBox.KeyPress += new KeyPressEventHandler(keypressed);
    
    private void keypressed(Object o, KeyPressEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.Handled = true; //this line will do the trick
        }
    }
