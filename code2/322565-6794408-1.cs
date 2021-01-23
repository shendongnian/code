        private void removeEndingsButton_Click(object sender, EventArgs e)
        {
            string[] items;
            System.Windows.Forms.ListBox.ObjectCollection contents = placementOneListBox.Items;
    
            foreach (string str in contents)
            {
               items = str.Split(' ');
               placementOneListBox.Items.Equals(string.Concat(items[0], " ", items[1], " ", items[2], " ", items[3]));
            }
        }
 
