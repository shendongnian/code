        private void MoveUp()
        {
            MoveItem(-1,listBox1);
        }      
 
        private void MoveDown()
        {
            MoveItem(1,listBox1);
        }
        public void MoveItem(int direction,ListBox listBox)
        {
            // Checking selected item
            if (listBox.SelectedItem == null || listBox.SelectedIndex < 0)
                return; // No selected item - nothing to do
            // Calculate new index using move direction
            int newIndex = listBox.SelectedIndex + direction;
            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= listBox.Items.Count)
                return; // Index out of range - nothing to do
            object selected = listBox.SelectedItem;
            // Removing removable element
            listBox.Items.Remove(selected);
            // Insert it in new position
            listBox.Items.Insert(newIndex, selected);
            // Restore selection
            listBox.SetSelected(newIndex, true);
        }
