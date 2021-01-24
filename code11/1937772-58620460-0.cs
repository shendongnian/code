    // Floors List View
    _floorsTableView = new ListView(this);
    // Create parameters for the listview
    RelativeLayout.LayoutParams parameters = new RelativeLayout.LayoutParams(100, 150);
    parameters.AddRule(LayoutRules.AlignParentBottom);
    parameters.AddRule(LayoutRules.AlignParentLeft);
    
    _floorsTableView.TextAlignment = TextAlignment.Center;
    var adap = new ArrayAdapter(this, Resource.Layout.SimpleSpinnerItem, new List<string>() { "1", "2", "3" });
    _floorsTableView.Adapter = adap;
    _floorsTableView.Visibility = ViewStates.Visible;
    
    // Add the listview to the layout with parameters specified
    layout.AddView(_floorsTableView, parameters);
