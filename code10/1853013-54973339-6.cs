    private void btnPrevious_Click(object sender, EventArgs e)
    {
        if (listView1.Items.Count > 0 && listView1.SelectedItems.Count > 0) {
            int currentItem = listView1.SelectedItems[listView1.SelectedItems.Count - 1].Index;
            listView1.Items[currentItem].Selected = false;
            listView1.Items[currentItem].EnsureVisible();
        }
        listView1.Focus();
    }
