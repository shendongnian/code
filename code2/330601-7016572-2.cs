    foreach (string item in itemList)
    {
        int insertPos = 0;
        bool itemIsFID = item.Contains("FID");
        while (insertPos < listBox.Items.Count)
        {
            // Primary sort - put FID items ahead of non-FID items
            bool boxItemIsFID = listBox.Items[insertPos].Contains("FID");
            if (itemIsFID && !boxItemIsFID)
            {
                // The new item must be inserted before the existing item
                break;
            }
            // Secondary sort - alphabetical
            if (item.CompareTo(listBox.Items[insertPos]) > 0)
            {
                // The new item must be inserted before the existing item
                break;
            }
        }
        // Insert the item at the location we've found
        if (insertPos < listBox.Items.Count)
            listBox.Items.Insert(insertPos, item);
        else
            listBox.Items.Add(item);
    }
Or finally, you could Pre-sort a collection of the items by implementing your own IComparer and using your collection's Sort method:
    itemList.Sort(MyComparer);
    foreach (string item in itemList)
        listbox.Items.Add(item);
