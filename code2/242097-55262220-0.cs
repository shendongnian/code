	public static void MoveUp(this ListBox listBox)
	{
		listBox.MoveItem(-1);
	}
	public static void MoveDown(this ListBox listBox)
	{
		listBox.MoveItem(1);
	}
	public static void MoveItem(this ListBox listBox, int direction)
	{
		// Checking selected item
		if (listBox.SelectedItem == null || listBox.SelectedIndex < 0)
			return; // No selected item - nothing to do
		// Calculate new index using move direction
		int newIndex = listBox.SelectedIndex + direction;
		// Checking bounds of the range
		if (newIndex < 0 || newIndex >= listBox.Items.Count)
			return; // Index out of range - nothing to do
		//Find our if we're dealing with a BindingSource
		bool isBindingSource = listBox.DataSource is BindingSource;
		//Get the list
		System.Collections.IList list = isBindingSource ? ((BindingSource)listBox.DataSource).List : listBox.Items;
		object selected = listBox.SelectedItem;
		// Removing removable element
		list.Remove(selected);
		// Insert it in new position
		list.Insert(newIndex, selected);
		// Restore selection
		listBox.SetSelected(newIndex, true);
		if (isBindingSource)
		{
			//Reset the binding if needed
			((BindingSource)listBox.DataSource).ResetBindings(false);
		}
	}
