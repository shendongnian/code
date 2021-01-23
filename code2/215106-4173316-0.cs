    public string DataBridgeAppend(string s)
    {
        txtHistory.Text += s + Environment.Newline;
        // or even better  txtHistory.AppendText(s + Environment.Newline);
    }
