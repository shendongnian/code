    for (int i = 0; i < listView1.SelectedItems.Count; i++)
    {
        //Selecting the each values of the selected item from listview
        // here You are only saving last selected item
        // instead of this do sth like
        // selectedItems.Add(sth that identifies this item, not index)
        listView_Selected_Index = listView1.SelectedIndices[i];
    }
