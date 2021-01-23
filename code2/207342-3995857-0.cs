    void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        int idx = list.SelectedIndex;
        int startIdx = idx - 2;
        int endIdx = idx + 2;
        if (startIdx < 0)
        {
            startIdx = 0;
        }
        if (endIdx >= list.Items.Count)
        {
            endIdx = list.Items.Count-1;
        }
    
        for (int i = startIdx; i <= endIdx; i++)
        {
            if (i != idx)
            {
                list.SelectedItems.Add(list.Items[i]);
            }
        }
    }
