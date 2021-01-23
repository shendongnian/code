    private void RemoveSelectedButton_Click(object sender, RoutedEventArgs e) {
            if (SelectedSpritesListBox.Items.Count <= 0) return;
            ListBoxItem[] temp = new ListBoxItem[SelectedSpritesListBox.SelectedItems.Count];
            SelectedSpritesListBox.SelectedItems.CopyTo(temp, 0);
            for (int i = 0; i < temp.Length; i++) {
                SelectedSpritesListBox.Items.Remove(temp[i]);
            }
        }
