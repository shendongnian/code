        private void removeEndingsButton_Click(object sender, EventArgs e)
        {
            string[] items;
            char[] splitChars = new char[] {'\t', ' '};
            int fieldCount;
            int lineCount = 0;
            System.Windows.Forms.ListBox.ObjectCollection contents = placementOneListBox.Items;
    
            foreach (string str in contents)
            {
               lineCount++;
               items = str.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
               fieldCount = items.Length;
               placementOneListBox.Items[lineCount] = string.Join(" ", items.Take(fieldCount - 1).ToArray());
            }
        }
 
