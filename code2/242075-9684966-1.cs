	 public void MoveUp()
	 {
		 MoveItem(-1);
	 }
	 public void MoveDown()
	 {
		MoveItem(+1);
	 }
	 public void MoveItem(int direction)
	 {
        // Checking selected item
		if (listBox1.SelectedItem == null || listBox1.SelectedIndex < 0)
			return;
        // Calculate new index using move direction
		int newIndex = listBox1.SelectedIndex + direction;
        // Checking bounds of the range
		if (newIndex < 0 || newIndex >= listBox1.Items.Count)
			return;
		object selected = listBox1.SelectedItem;
        // Removing removable element
		listBox1.Items.Remove(selected);
        // Insert it in new position
		listBox1.Items.Insert(newIndex, selected);
        // Restore selection
		listBox1.SetSelected(newIndex, true);
	}
