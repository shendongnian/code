    private void OnFormLoad(object sender, EventArgs e)
    {
        this.KeyDown += OnKeyDown;
        foreach (Control control in this.Controls)
        {
            control.KeyDown += OnKeyDown;
        }
    }
    private void OnKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Control)
        {
            if (e.KeyValue == (int)Keys.S)
            {
                Console.WriteLine("ctrl + s");
            }
        }
    }
