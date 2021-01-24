        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (itemListBox.SelectedIndex > -1)
                itemListBox.Items.RemoveAt(itemListBox.SelectedIndex);
            else
                MessageBox.Show("No item exist in the list box, operation fail");
        }
