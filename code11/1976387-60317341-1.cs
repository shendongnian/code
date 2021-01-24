	IEnumerable<MyClassSelectable> myCollection;
    // the query is in the 1st parameter of the ObservableCollection constructor
	var obserColl = new ObservableCollection<MyClassSelectable>(myCollection
        // group by the Selected property
		.GroupBy(mcs => mcs.Selected)
        // order (=> true first, false second)
		.OrderByDescending(g => g.Key)
        // return the first OR an empty collection if there are no items
		.FirstOrDefault() ?? (IEnumerable<MyClassSelectable>)(new List<MyClassSelectable>()));
