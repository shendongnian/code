    void Form1_Load(object sender, EventArgs e)
    {
        TestIt();
    }
    public void TestIt()
    {
        string enl = "Cheese" + Environment.NewLine + "Whiz";
        RichTextBox rtb = new RichTextBox();
        MessageBox.Show("preinit rtb.Rtf : '" + rtb.Rtf + "'");
        this.Controls.Add(rtb);
        MessageBox.Show("postinit rtb.Rtf : '" + rtb.Rtf + "'");
        MessageBox.Show("richTextBox1.Rtf : '" + richTextBox1.Rtf + "'");
        rtb.Text = enl;
        string ncr = rtb.Text;
        MessageBox.Show(string.Format("rtb: {0}{1}{2}{3}---{4}{5}{6}{7}{8}{9}",
                                      enl.Replace("\n", "\\n").Replace("\r", "\\r"), Environment.NewLine,
                                      ncr.Replace("\n", "\\n").Replace("\r", "\\r"), Environment.NewLine,
                                      Environment.NewLine,
                                      (enl == ncr), Environment.NewLine,
                                      enl.Contains(Environment.NewLine), Environment.NewLine,
                                      ncr.Contains(Environment.NewLine)));
        /*
        Cheese\r\nWhiz
        Cheese\nWhiz
        ---
        False
        True
        False
        */
        richTextBox1.Text = enl;
        string ncr2 = richTextBox1.Text;
        MessageBox.Show(string.Format("richTextBox1: {0}{1}{2}{3}---{4}{5}{6}{7}{8}{9}",
                                      enl.Replace("\n", "\\n").Replace("\r", "\\r"), Environment.NewLine,
                                      ncr2.Replace("\n", "\\n").Replace("\r", "\\r"), Environment.NewLine,
                                      Environment.NewLine,
                                      (enl == ncr2), Environment.NewLine,
                                      enl.Contains(Environment.NewLine), Environment.NewLine,
                                      ncr2.Contains(Environment.NewLine)));
        /*
        Cheese\r\nWhiz
        Cheese\nWhiz
        ---
        False
        True
        False
        */
    }
