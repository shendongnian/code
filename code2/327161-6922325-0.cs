        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedIndex < 0 || !listBox1.GetItemRectangle(listBox1.SelectedIndex).Contains(e.Location))
                MessageBox.Show("no click");
            else
                MessageBox.Show("click on item " + listBox1.SelectedIndex.ToString());
        }
