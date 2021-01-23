        private void SetSelectedItem(string selectedString)
        {
            Func<ComboBoxItem, ComboBoxItem> selectionFunc = (item) =>
            {
                if(item.Content.ToString() == selectedString)
                    return item;
                return null;
            };
            this.MyComboBox.SelectedItem = MyComboBox.Items.Select(s => selectionFunc(s as ComboBoxItem)).FirstOrDefault();
        }
