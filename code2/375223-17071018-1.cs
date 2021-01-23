    private DockablePane _collapsedDocumentPane;
    private DockablePane CollapsedDocumentPane
    {
      get
      {
        if (_collapsedDocumentPane== null)
        {
            _collapsedDocumentPane= new DockablePane();
            var a = new DockableContent
            {
               Title = "A",
               DataContext = _youViewModel, //if you pass data context
               DockableStyle = DockableStyle.AutoHide,
               Content = new RadGridView(), //just a sample control
             };
             var b = new DockableContent { Title = "B"};
            _collapsedDocumentPane.Items.Add(a);
            _collapsedDocumentPane.Items.Add(b);
         }
         return _errorsDockablePane;
       }
     }
