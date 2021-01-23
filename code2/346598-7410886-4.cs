    private List<SomeItem> _Items = new List<SomeItem>();
    // Add an item.
    _Items.Add(new SomeItem("ABC"));
    
    // Add a changed item.
    SomeItem itemN = new SomeItem("EFG");
    itemN.Value = "XYZ";
    _Items.Add(itemN);
    
    
    foreach (SomeItem item in _Items)
    {
       if (item.HasChanged)
       {
          // Do stuff here.
          //throw new Exception()
       }
    }
