    public static void MoveUpOrDownSelectedItem(ListBox LisBox, bool MoveUp)
     {
              if (LisBox.SelectedIndex > 0 && MoveUp)
              {
                 // add a duplicate item up in the listbox
                 LisBox.Items.Insert(LisBox.SelectedIndex - 1, LisBox.SelectedItem);
                 // make it the current item
                 LisBox.SelectedIndex = (LisBox.SelectedIndex - 2);
                 // delete the old occurrence of this item
                  LisBox.Items.RemoveAt(LisBox.SelectedIndex + 2);
              }
            if ((LisBox.SelectedIndex != -1) && (LisBox.SelectedIndex < LisBox.Items.Count- 1) && MoveUp == false)     
            {
                // add a duplicate item down in the listbox
                int IndexToRemove = LisBox.SelectedIndex;
                LisBox.Items.Insert(LisBox.SelectedIndex + 2, LisBox.SelectedItem);
                // make it the current item
                LisBox.SelectedIndex = (LisBox.SelectedIndex + 2);
                // delete the old occurrence of this item
                LisBox.Items.RemoveAt(IndexToRemove);
            }
        }
