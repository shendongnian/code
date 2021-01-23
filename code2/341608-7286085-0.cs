    System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
    t.Interval = 3000;
    t.Start();
    t.Tick += new EventHandler(t_Tick);
    void t_Tick(object sender, EventArgs e)
    {
         label.Visible = false;
    }
