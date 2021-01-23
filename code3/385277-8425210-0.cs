        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                Clipboard.SetText(listView1.SelectedItems[0].Text);
            }
        }
