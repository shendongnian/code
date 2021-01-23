    private void button1_Click(object sender, EventArgs e)
    {
        tabControl1.TabPages.Add("t1", "new 1");
        var tb = new TextBox();
        tb.TextChanged += (bs, be) =>
        {
            MessageBox.Show("Text has been changed");
        };
        tabControl1.TabPages["t1"].Controls.Add(tb);
    }
