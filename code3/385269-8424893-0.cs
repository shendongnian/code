    private void button1_Click(object sender, EventArgs e)
    {
        foreach (ListViewItem item in listView1.CheckedItems)
        {
            listView1.Items.Remove(item);
        }
    }
