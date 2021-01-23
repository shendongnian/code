        private void removeEndingsButton_Click(object sender, EventArgs e)
        {
            string[] items;
            char[] splitChars = new char[] {'\t', ' '};
            int count;
            System.Windows.Forms.ListBox.ObjectCollection contents = placementOneListBox.Items;
    
            foreach (string str in contents)
            {
               items = str.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
               count = items.Length;
               placementOneListBox.Items.Equals(string.Join(" ", items.Take(count - 1).ToArray()));
            }
        }
 
