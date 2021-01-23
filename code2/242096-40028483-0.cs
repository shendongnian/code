            private void Order_buttons_Click(object sender, EventArgs e)
        {
            //If noselection return
            if (Layouts_listBox.SelectedItems.Count == 0) return;
            //Determines wether up or down
            int movement = (sender as Button) == Order_Upbutton? - 1 : 1;
            //creates a dictionary associating the original Index (ListBox) to the text
            Dictionary<int, string> Items = new Dictionary<int, string>();
            //Also creates a list with the Index for sorting
            List<int> DesiredOrder = new List<int>();
            //Cycle through the selection and fill both the list and dictionary
            ListBox.SelectedObjectCollection NN = Layouts_listBox.SelectedItems;
            foreach (object n in NN)
            {
                DesiredOrder.Add(Layouts_listBox.Items.IndexOf(n));
                Items.Add(Layouts_listBox.Items.IndexOf(n), (string)n);
            }
            //Sort the List according to the desired button (Up or Down)
            DesiredOrder.Sort();
            if ((sender as Button) != Order_Upbutton) DesiredOrder.Reverse();
            //I'm using this ErrorHandling but thats up to you
            try
            {
                //Call the MoveItem (Credits to Save) according to the sorted order
                foreach (int n in DesiredOrder) MoveItem(movement, Items[n]);
            }
            catch (Exception)
            {
                SystemSounds.Asterisk.Play();
            }
        }
        public void MoveItem(int direction, string Selected)
        {
            // Checking selected item
            if (!Layouts_listBox.Items.Contains(Selected) || Layouts_listBox.Items.IndexOf(Selected) < 0)
                throw new System.Exception(); // No selected item - Cancel entire Func
            // Calculate new index using move direction
            int newIndex = Layouts_listBox.Items.IndexOf(Selected) + direction;
            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= Layouts_listBox.Items.Count)
                throw new System.Exception(); // Index out of range - Cancel entire Func
            object selected = Layouts_listBox.Items[Layouts_listBox.Items.IndexOf(Selected)];
            // Removing removable element
            Layouts_listBox.Items.Remove(selected);
            // Insert it in new position
            Layouts_listBox.Items.Insert(newIndex, selected);
            // Restore selection
            Layouts_listBox.SetSelected(newIndex, true);
        }
