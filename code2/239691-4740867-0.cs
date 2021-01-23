    public IEnumerable<object> BindingList
    {
      get { return (IEnumerable<object>)base.GetValue(BindingListProperty); }
      set { base.SetValue(BindingListProperty, value); }
    }
    
    public static DependencyProperty BindingListProperty =
      DependencyProperty.Register(
      "BindingList",
      typeof(IEnumerable<object>),
      typeof(CustomControl),
      new PropertyMetadata(null));
