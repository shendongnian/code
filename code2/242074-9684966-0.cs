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
		if (listBox1.SelectedItem == null || listBox1.SelectedIndex < 0)
			return;
		int newIndex = listBox1.SelectedIndex + direction;
		if (newIndex < 0 || newIndex >= listBox1.Items.Count)
			return;
		object selected = listBox1.SelectedItem;
		listBox1.Items.Remove(selected);
		listBox1.Items.Insert(newIndex, selected);
		listBox1.SetSelected(newIndex, true);
	}
