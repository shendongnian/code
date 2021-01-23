    Dim view As ListCollectionView = CollectionViewSource.GetDefaultView(myCollection)
     Using view.DeferRefresh
        view.SortDescriptions.Clear()
        view.SortDescriptions.Add(New SortDescription(sortHeader.Header, direction))
        view.SortDescriptions.Add(New SortDescription(otherColumn, direction))
        view.CustomSort = New MyComparer(PropertyPath)
     End Using
