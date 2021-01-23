    public TagCloudControl()
    {
        **Tags = new IEnumerable<Tags>;**
        ItemsSource = Tags;
        //group my tags by "name" property
        GroupedTagsView = (ListCollectionView)CollectionViewSource.GetDefaultView(Tags);
        GroupedTagsView.GroupDescriptions.Add(new PropertyGroupDescription("Name"));
    } 
