    int i = 0;
    while (i < listView1.Items.Count)
    {
        if (listView.Items[i].Checked)
        {
            string sql = "uscolumn = '" + listView1.Items[i].SubItems[0].Text + "' and ukcolumn = '" + listView1.Items[i].SubItems[1].Text + "'";                 
            listView.Items.RemoveAt(i);
        }
        else
        {
            i++;
        }
    }
