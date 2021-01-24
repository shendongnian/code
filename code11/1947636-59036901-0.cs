    ...
    // Add list of checked-out items to Document
    Microsoft.Office.Interop.Word.Paragraph ul = doc.Content.Paragraphs.Add(ref missing);
    
    // Get a list of all items that are checked. This allows us to know how many
    // there are for when we add them later.
    List<string> checkedItems = GetCheckedItems();
    
    // Only apply the bullet formatting if at least one item is checked. This keeps
    // us from adding an empty bullet in the case that nothing is checked.
    if (checkedItems.Count > 0)
    {
        ul.Range.ListFormat.ApplyBulletDefault();
    }
    
    for (int i = 0; i < checkedItems.Count; i++)
    {
        // If this isn't the last item then add a newline.
        if (i != checkedItems.Count - 1)
        {
            ul.Range.InsertBefore(checkedItems[i] + "\n");
        }
        // If this is the last item don't add a newline, otherwise we'll get an 
        // empty bullet at the end.
        else
        {
            ul.Range.InsertBefore(checkedItems[i]);
        }
    }
    ...
    private List<string> GetCheckedItems()
    {
        List<string> items = new List<string>();
        if (listItem1CheckBx.Checked)
        {
            items.Add(listItem1CheckBx.Text);
        }
        if (listItem2CheckBx.Checked)
        {
            items.Add(listItem2CheckBx.Text);
        }
        if (listItem3CheckBx.Checked)
        {
            items.Add(listItem3CheckBx.Text);
        }
        if (listItem4CheckBx.Checked)
        {
            items.Add(listItem4CheckBx.Text);
        }
        if (listItem5CheckBx.Checked)
        {
            items.Add(listItem5CheckBx.Text);
        }
        if (otherChckBx.Checked)
        {
            items.Add(otherListItemTxtBx.Text);
        }
        return items;
    }
