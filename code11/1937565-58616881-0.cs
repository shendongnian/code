foreach(var item in checkedListBox1.CheckedItems.Cast<object>().ToList())
{
    listBox1.Items.Add(checkedListBox1.GetItemText(item));
    checkedListBox1.Items.Remove(item);
}
Good luck.
