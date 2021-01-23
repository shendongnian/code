        //Counter to differentiate list items
        private int counter = 1;
        private void button1_Click(object sender, EventArgs e)
        {
            //Add a new item to the list
            listView1.Items.Add(new ListViewItem("List item " + counter++.ToString()));
        }
        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //Get the item that was checked / unchecked
            ListViewItem l = listView1.Items[e.Index];
            //Display message
            if (e.NewValue == CheckState.Checked)
                MessageBox.Show(l.ToString() + " was just checked.");
            else if (e.NewValue == CheckState.Unchecked)
                MessageBox.Show(l.ToString() + " was just unchecked.");
        }
