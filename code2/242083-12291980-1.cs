    private void MoveUp_listBox_button_Click(object sender, EventArgs e)
    {
      listBox.BeginUpdate();
      int numberOfSelectedItems = listBox.SelectedItems.Count;
      for (int i = 0; i < numberOfSelectedItems; i++)
      {
        // only if it's not the first item
        if (listBox.SelectedIndices[i] > 0)
        {
          // the index of the item above the item that we wanna move up
          int indexToInsertIn = listBox.SelectedIndices[i] - 1;
          // insert UP the item that we want to move up
          listBox.Items.Insert(indexToInsertIn, listBox.SelectedItems[i]);
          // removing it from its old place
          listBox.Items.RemoveAt(indexToInsertIn + 2);
          // highlighting it in its new place
          listBox.SelectedItem = listBox.Items[indexToInsertIn];
        }
      }
      listBox.EndUpdate();
    }
        
    private void MoveDown_listBox_button_Click(object sender, EventArgs e)
    {
      listBox.BeginUpdate();
      int numberOfSelectedItems = listBox.SelectedItems.Count;
      // when going down, instead of moving through the selected items from top to bottom
      // we'll go from bottom to top, it's easier to handle this way.
      for (int i = numberOfSelectedItems-1; i >= 0; i--)
      {
        // only if it's not the last item
        if (listBox.SelectedIndices[i] < listBox.Items.Count - 1)
        {
          // the index of the item that is currently below the selected item
          int indexToInsertIn = listBox.SelectedIndices[i] + 2;
          // insert DOWN the item that we want to move down
          listBox.Items.Insert(indexToInsertIn, listBox.SelectedItems[i]);
          // removing it from its old place
          listBox.Items.RemoveAt(indexToInsertIn - 2);
          // highlighting it in its new place
          listBox.SelectedItem = listBox.Items[indexToInsertIn - 1];
        }
      }
      listBox.EndUpdate();
    }
