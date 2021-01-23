    public void MoveItem(int direction)
            {
                // Checking selected item
                if (listBox1.SelectedItem == null || listBox1.SelectedIndex < 0)
                    return; // No selected item - nothing to do
    
                // Calculate new index using move direction
                int newIndex = listBox1.SelectedIndex + direction;
    
                // Checking bounds of the range
                if (newIndex < 0 || newIndex >= listBox1.Items.Count)
                    return; // Index out of range - nothing to do
    
                UnifyCamera selected = listBox1.SelectedItem as UnifyCamera;
                
                // modify the data source list
                inputData.Cameras.RemoveAt(listBox1.SelectedIndex);
                inputData.Cameras.Insert(newIndex, selected);
                
                // re-bind your data source
                ((ListBox)listBox1).DataSource = null;
                ((ListBox)listBox1).DataSource = this.inputData.Cameras;
                ((ListBox)listBox1).DisplayMember = "Name";
    
                // Restore selection
                listBox1.SetSelected(newIndex, true);
            }
