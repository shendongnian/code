    private void LoadTree(ListView lstViewChild)
    {
    string path = "";
    int ctr = 0, i = 0;
    while (i < lstViewChild.Count)
    {
        ListViewItem lvi = lstViewChild.Items[i];
        if (lvi.SubItems[2].Text != path)
        {
            path = lvi.SubItems[2].Text;
            ctr = 0;
            skipme = false;
    
            //I think its here where you want to recursively call it
            LoadTree(lvi);  //<-- here we call this method again, be careful as each time you call it, it add to the call stack and when you exhaust that it results in a STACKOVERFLOW exception!
        }
        if (!skipme)
        {
            ctr++;
    
            lvi.EnsureVisible();
            lvi.Checked = true;
        }
            //Process
    
    
         
        i++;
    }
    }
