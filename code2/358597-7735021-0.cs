    var p = new Process();
    p.EnableRaisingEvents = true;
    p.Exited += new EventHandler(p_Exited);
    public void p_Exited(object sender, EventArgs e)
    {
        //handle exiting of process here.
    }
