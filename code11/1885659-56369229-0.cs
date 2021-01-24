    private void LbFiles_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        var sourceList = lbFiles.ItemsSource
                                .OfType<object>()
                                .ToList();
    
        var moveLast = sourceList[sourceList.Count - 1];
    
        sourceList.RemoveAt(sourceList.Count - 1);
    
        var newList = new List<object>() { moveLast };
    
        newList.AddRange(sourceList);
    
        lbFiles.ItemsSource = newList;
    }
