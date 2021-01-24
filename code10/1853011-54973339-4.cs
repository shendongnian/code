    private void btnNext_Click(object sender, EventArgs e)
    {
        if (listView1.Items.Count == 0) return;
        int currentItem = listView1.SelectedItems.Count == 0 
                        ? -1 
                        : listView1.SelectedItems[listView1.SelectedItems.Count - 1].Index;
        if (currentItem < listView1.Items.Count - 1) {
            listView1.Items[currentItem + 1].Selected = true;
            listView1.Items[currentItem + 1].EnsureVisible();
        }
        listView1.Focus();
    }
