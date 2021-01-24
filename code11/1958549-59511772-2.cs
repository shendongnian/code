        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
           AddToListBox(InputText.Text);
        }
        private void AddToListBox(string newItem)
        {
            if (Names.Items.Contains(newItem))
                MessageBox.Show("Sorry that item is already in the listbox.");
            else
                Names.Items.Add(newItem);
        }
