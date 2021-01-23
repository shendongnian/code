    public CollectionViewSource GetSortedView{
       get{
          CollectionViewSource view = new CollectionViewSource(myColl);
          view.SortDescriptors.Add(new SortDescriptor("propertyname"), Ascending);
          return view;
       }
    }
