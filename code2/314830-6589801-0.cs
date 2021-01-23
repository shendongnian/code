    using ListViewCollection = System.Windows.Forms.ListView.ListViewItemCollection;
    
    void FillDirectories ( )
    {
        IEnumerable<DirectoryInfo> pathDirInfos = currentPath.EnumerateDirectories ( );
    
        var dirItems = ( from d in pathDirInfos
                         select new ListViewItem
                         {
                             Name = d.Name,
                             Text = d.Name,
                         } )
                       .ToArray ( );
    
        ListViewCollection listItems = new ListViewCollection ( uxExplorerListView );
        listItems.AddRange ( dirItems );
    }
