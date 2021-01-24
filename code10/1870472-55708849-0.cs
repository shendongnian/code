    void lvproducten_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lvproducten.SelectedItems.Count > 0)
        {
            string id = listView1.SelectedItems[0].SubItems[0].Text;
            string product = listView1.SelectedItems[0].SubItems[1].Text;
            .... update your textboxes....
        }
    }
