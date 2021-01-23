    this.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.Control_Added);
    private void Control_Added(object sender, System.Windows.Forms.ControlEventArgs e)
    {
        if (e.Control is Form)
            ((Form)e.Control.BackColor = Color.Blue;
    }
