    List<string> checkedItems = new List<string>();
            foreach (var item in checkedListBox1.CheckedItems)
                checkedItems.Add(item.ToString());
    
            if (e.NewValue == CheckState.Checked)
                checkedItems.Add(checkedListBox1.Items[e.Index].ToString());
            else
                checkedItems.Remove(checkedListBox1.Items[e.Index].ToString());
    
             StringBuilder builder = new StringBuilder();
            foreach (string item in checkedItems)
            {
                 builder.Append(item).Append("|");
            }
           label1.Text = builder.ToString();
