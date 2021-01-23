        private void listView1_SelectedIndexChanged(object sender, EventArgs e) {
            if (listView1.SelectedItems.Count > 0) {
                textBox1.Text = listView1.SelectedItems[0].Text;
            }
            else {
                textBox1.Text = string.Empty;
            }
        }
