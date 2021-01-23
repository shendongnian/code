             private bool isInitialized = false;
             private void listView1_SelectedIndexChanged(object sender, EventArgs e) {
                 if (isInitialized) {
                     ListView.SelectedListViewItemCollection collection = this.listView1.SelectedItems;
    
                     if (collection.Count == 0) {
                         this.label2.Text = "Unselected all!";
                     }
                     foreach (ListViewItem item in collection) {
                         getSideInformation(item.Text);
                     }
                 }
                 isInitialized = true;
            }
