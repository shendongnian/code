        List<int> groups = new List<int>();
        foreach (var item in clbGroup.CheckedItems)
        {
            ListViewItem foundItem = listViewGroups.FindItemWithText(item.ToString(), false, 0, false);
            if (foundItem != null)
            {
                groups.Add(Convert.ToInt32(foundItem.Tag));
            }
        }
