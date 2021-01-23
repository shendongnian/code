        private void listBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e) 
        {
            // Get the index of the item the mouse is below.
            indexOfItemUnderMouseToDrag = listBox.IndexFromPoint(e.X, e.Y);
            if (indexOfItemUnderMouseToDrag != ListBox.NoMatches) {
                // Remember the point where the mouse down occurred. The DragSize indicates
                // the size that the mouse can move before a drag event should be started.                
                Size dragSize = SystemInformation.DragSize;
                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width /2),
                                                               e.Y - (dragSize.Height /2)), dragSize);
            } else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
        }
        private void listBox_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e) {
            // Reset the drag rectangle when the mouse button is raised.
            dragBoxFromMouseDown = Rectangle.Empty;
        }
        private void listBox_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e) 
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left) {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty && 
                    !dragBoxFromMouseDown.Contains(e.X, e.Y)) 
                {
                        DragDropEffects dropEffect = listBox.DoDragDrop(listBox.Items[indexOfItemUnderMouseToDrag], DragDropEffects.All | DragDropEffects.Link);
                        // If the drag operation was a move then remove the item.
                        if (dropEffect == DragDropEffects.Move) {                        
                            listBox.Items.RemoveAt(indexOfItemUnderMouseToDrag);
                            // Selects the previous item in the list as long as the list has an item.
                            if (indexOfItemUnderMouseToDrag > 0)
                                listBox.SelectedIndex = indexOfItemUnderMouseToDrag -1;
                            else if (ListDragSource.Items.Count > 0)
                                // Selects the first item.
                                listBox.SelectedIndex =0;
                        }
                    }
                }
            }
        }
