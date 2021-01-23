    private void Form1_Load(object sender, EventArgs e)
    {
        this.KeyUp += new KeyEventHandler(Form1_KeyUp);
    }
    void Form1_KeyUp(object sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.NumPad1:
                break;
            case Keys.NumPad2:
                break;
                //...
        }
    }
