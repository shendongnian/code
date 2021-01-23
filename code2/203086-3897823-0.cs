        private void listView1_MouseClick(object sender, MouseEventArgs e) {
            if (allowContextMenu(listView1.SelectedItems) {
                contextMenuStrip1.Show(listView1, e.Location);
            }
        }
