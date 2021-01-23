    var idIdx = listView1.Columns["ID"].Index;
    var codeIdx = listView1.Columns["Code"].Index;
    
    foreach (ListViewItem item in listView1.Items)
    {
        if (item.SubItems[idIdx].Text == "2")
        {
            item.SubItems[codeIdx].Text = "new value...";
            break;
        }
    }
