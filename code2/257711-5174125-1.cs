    public TagCloudControl()
    {
        **Tags = new ObservableCollection<Tags>();**
        ItemsSource = Tags;
        //group my tags by "name" property
        GroupedTagsView = (ListCollectionView)CollectionViewSource.GetDefaultView(Tags);
        GroupedTagsView.GroupDescriptions.Add(new PropertyGroupDescription("Name"));
    } 
