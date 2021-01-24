    foreach (string a in ListBox1.Items)
    {
        var arr = a.Replace(" ", "").Split(',');
    
        ListViewItem lvi = new ListViewItem(arr[0]);
    
        for(int i = 1; i < arr.Length;i++)
        {
            if(i >= ListView1.Columns.Count )
            {
                ListView1.Columns.Add($"Column {i}");
            }
            lvi.SubItems.Add(arr[i]);
        }
        ListView1.Items.Add(lvi);
    }
