    protected void filingList_Click(object sender, BulletedListEventArgs e)
    {
        var value = filingList.Items[e.Index].Value;
        using(var client = new WebClient())
        {
            string downloadString = client.DownloadString(value);
            filingLiteral.Text = downloadString;  
        }
    }
