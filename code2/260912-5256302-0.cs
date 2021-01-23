    foreach (var group in objects.GroupBy(x => x.TimeSpan.TotalSeconds % 20))
    {
        MessageBox.Show(groups.Count());
        foreach (var groupItem in group) 
        {
            MessageBox.Show(groupItem.A);
            MessageBox.Show(groupItem.B);
        }
    }
