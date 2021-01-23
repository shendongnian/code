    private void Form1_Load(object sender, EventArgs e)
    {
        AssignHandler(this);
    }
    
    protected void HandleKeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter && (sender != this.textBoxToIgnore || sender ! this.gridViewToIgnore))
        {
            PlaySound();  // your error sound function
            e.Handled = true;
        }
    }
    
    public void AssignHandler(Control c)
    {
        c.KeyPress += new KeyPressEventHandler(HandleKeyPress);
        foreach (Control child in c.Controls)
        {
            AssignHandler(child);
        }
    }
   
