    protected void Page_Load(object sender, EventArgs e)
    {
        var ctrls = new List<Control>();
        foreach (Control c in pnlLinks.Controls)
        {
            ctrls.Add(c);
        }
        Random rand = new Random();
        //randomize and put back in
        foreach (Control c in ctrls.OrderBy(c => rand.Next()))
        {
            pnlLinks.Controls.Remove(c);
            pnlLinks.Controls.Add(c);
        }
    }
