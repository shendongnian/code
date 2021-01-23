    private ComboBox[] cmb;
    private void init()
    {
        cmb = new ComboBox[5];
        for (int i = 0; i < 5; i++)
        {
            ComboBox c = new ComboBox();
            Controls.Add(c);
            // TODO: Populate c with the relevant data
            c.TextChanged += new EventHandler(c_TextChanged);
        }
        chk.CheckedChanged += new EventHandler(chk_CheckedChanged);
    }
    void chk_CheckedChanged(object sender, EventArgs e)
    {
        foreach (ComboBox c in cmb)
            c.Text = "Full";
    }
    void c_TextChanged(object sender, EventArgs e)
    {
        foreach (ComboBox c in cmb)
        {
            if (c.Text != "Full") return;
        }
        chk.Checked = false;
    }
