    //Change the top left button to a CheckBox
    void StyleSelectAllButton(DependencyObject dependencyObject)
    {
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(dependencyObject); i++)
        {
            var child = VisualTreeHelper.GetChild(dependencyObject, i);
            if ((child != null) && child is Button)
            {
                var grid = (Grid)VisualTreeHelper.GetChild(child, 0);
                var checkBox = new CheckBox()
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                };
                checkBox.Click += OnCheckBoxClicked;
                grid.Children.Clear();
                grid.Children.Add(checkBox);
            }
            else
            {
                StyleSelectAllButton(child);
            }
        }
    }
    //Action when the top left check box checked and unchecked
    void OnCheckBoxClicked(object sender, RoutedEventArgs e)
    {
        var checkBox = sender as CheckBox;
        if (checkBox == null)
        {
            return;
        }
        if (checkBox.IsChecked == true)
        {
            //Change the 'dataGrid' to your DataGrid instance name
           dataGrid.SelectAllCells(); 
        }
        else
        {
            //Change the 'dataGrid' to your DataGrid instance name
            dataGrid.UnselectAllCells();
        }
    }
