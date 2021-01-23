    for (int i = 0; i < myListView.Items.Count - 1; i++)
    {
        if (myListView.Items[i].Tag == myListVIew.Items[i + 1].Tag)
        {
           myListView.Items[i + 1].Remove();
        }
    }
