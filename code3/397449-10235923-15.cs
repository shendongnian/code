    //syncs the footer with column header resize
    private void OnDatagridScrollChanged(object sender, ScrollChangedEventArgs e)
    {
        if (e.HorizontalChange == 0.0) return;
        FooterScrollViewer.ScrollToHorizontalOffset(e.HorizontalOffset);
    }
    //syncs scroll
    private void OnDataColumnSizeChanged(object sender, SizeChangedEventArgs e)
    {
        //I don't know how many of these checks you need, skip if need to the gist
        if (!_isMouseDown) return;
        if (!_dataGridLoaded) return;
        if (!IsVisible) return;
	
	     var header = (DataGridColumnHeader)sender;
	     var index = header.DisplayIndex - ViewModel.NumberOfHeaderColumns;
        
         if (index < 0 || index >= FooterCells.Count) return;
	     FooterCells[index].Width = e.NewSize.Width;
    }
    //below referencing supporting properties:
    private ScrollViewer _footerScroll;
    private ScrollViewer FooterScrollViewer
    {
        get {
	        return _footerScroll ??
                  (_footerScroll = BosBaseGrid.FindVisualChildByName<ScrollViewer>("PART_Footer_ScrollViewer"));
            }
    }
    //added this so I don't have to hunt them down from XAML every time
    private List<Border> _footerCells;
    private List<Border> FooterCells
    {
        get
        {
            if (_footerCells == null)
            {
                var ic = myDataGrid.FindVisualChildByName<ItemsControl>("PART_Footer");
                _footerCells = new List<Border>();
                for (var i = 0; i < ic.Items.Count; i++)
                {
                   var container = ic.ItemContainerGenerator.ContainerFromIndex(i);				                
                   var border = ((Visual)container).FindVisualChild<Border>();
                  _footerCells.Add(border);
                }
             }
             return _footerCells;
        }
    }
