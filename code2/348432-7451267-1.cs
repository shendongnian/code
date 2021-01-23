    DataGrid dg = new DataGrid();
    dg.ScrollChanged += DoSomething;
    
    private void DoSomething(object sender, ScrollChangedEventArgs e)
    {
        if (e.HorizontalChange != 0)
        {
            // update some stuff to main XAML which should now be available
        }
    }
