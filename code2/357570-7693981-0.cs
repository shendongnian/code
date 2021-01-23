    private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                foreach (ListViewItem item in listView1.Items)
                    if (item.Text == comboBox1.SelectedItem.ToString()) listView1.Items.Remove(item);
            }
        }
