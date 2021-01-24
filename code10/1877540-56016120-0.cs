    public void YourFunction(Action action)
    {
        string path = "";
        int ctr = 0, i = 0;
        while (i < lvwArticles.Items.Count)
        {
            ListViewItem lvi = lvwArticles.Items[i];
            if (lvi.SubItems[2].Text != path)
            {
                path = lvi.SubItems[2].Text;
                ctr = 0;
                skipme = false;
            }
            if (!skipme)
            {
                ctr++;
        
                lvi.EnsureVisible();
                lvi.Checked = true;
            }
        
            //Process
            action();
        
            i++;
        }
    }
