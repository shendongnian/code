    int an = 10;
    private void Incoming_Click(object sender, EventArgs e)
    {
        MsgItem item = new MsgItem("testing");
        item.Top = an;
        an = item.Top + item.Height + 10;
        panel2.Controls.Add(item);
    }
