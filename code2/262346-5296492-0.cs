    private void init()
    {
        foreach(ComboBox c in cmb)
            c.TextChanged += new EventHandler(c_TextChanged);
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
