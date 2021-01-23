        private void myList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (myList.SelectedItems.Count  >= 1)
            {
                ListViewItem item = myList.SelectedItems[0];
                //here i check for the Mouse pointer location on click if its contained 
                // in the actual selected item's bounds or not .
                // cuz i ran into a problem with the ui once because of that ..
                if (item.Bounds.Contains(e.Location))
                {
                    MessageBox.Show("Double Clicked on :"+item.Text);
                }
            }
        }
