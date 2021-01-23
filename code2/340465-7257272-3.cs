    public ViewModelBase PropSelectedItem
    {
    get
     {
    switch(TreeMenuViewModelStatic.PropSelectedItem)
    {
      case "Booo": return typeof(View1);
      case "Foo": return typeof(View2);
    }
        
      }
    private set;
    }
