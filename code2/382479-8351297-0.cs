        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                int index = listBox2.Items.Count>0?listBox2.Items.Count:0;
                listBox2.Items.Insert(index, listBox1.SelectedItem);
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }
