        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            // find the lowest index of non selected items
            int lowestIndexNotSelected = listBox.Items.Count - 1;
            for (int i = listBox.Items.Count - 1; i >= 0; i--)
            {
                if (!listBox.SelectedIndices.Contains(i))
                {
                    lowestIndexNotSelected = i;
                }
            }
            listBox.BeginUpdate();
            int numberOfSelectedItems = listBox.SelectedItems.Count;
            for (int i = 0; i < numberOfSelectedItems; i++)
            {
                // only if it's not a lower inde than the lowest non selected index
                if (listBox.SelectedIndices[i] > lowestIndexNotSelected)
                {
                    // the index of the item above the item that we wanna move up
                    int indexToInsertIn = listBox.SelectedIndices[i] - 1;
                    // insert UP the item that we want to move up
                    listBox.Items.Insert(indexToInsertIn, listBox.SelectedItems[i]);
                    // removing it from its old place
                    listBox.Items.RemoveAt(indexToInsertIn + 2);
                    // highlighting it in its new place (by index, to prevent highlighting wrong instance)
                    listBox.SelectedIndex = indexToInsertIn;
                }
            }
            listBox.EndUpdate();
        }
        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            // find the highest index of non selected items
            int highestIndexNonSelected = 0;
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                if (!listBox.SelectedIndices.Contains(i))
                {
                    highestIndexNonSelected = i;
                }
            }
            
            listBox.BeginUpdate();
            int numberOfSelectedItems = listBox.SelectedItems.Count;
            // when going down, instead of moving through the selected items from top to bottom
            // we'll go from bottom to top, it's easier to handle this way.
            for (int i = numberOfSelectedItems - 1; i >= 0; i--)
            {
                // only if it's not a higher index than the highest index not selected
                if (listBox.SelectedIndices[i] < highestIndexNonSelected)
                {
                    // the index of the item that is currently below the selected item
                    int indexToInsertIn = listBox.SelectedIndices[i] + 2;
                    // insert DOWN the item that we want to move down
                    listBox.Items.Insert(indexToInsertIn, listBox.SelectedItems[i]);
                    // removing it from its old place
                    listBox.Items.RemoveAt(indexToInsertIn - 2);
                    // highlighting it in its new place (by index, to prevent highlighting wrong instance)
                    listBox.SelectedIndex = indexToInsertIn - 1;
                }
            }
            listBox.EndUpdate();
        }
