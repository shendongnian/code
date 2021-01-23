    public IObservable<object> BindingList
    {
      get { return (IObservable<object>)base.GetValue(BindingListProperty); }
      set { base.SetValue(BindingListProperty, value); }
    }
    
    public static DependencyProperty BindingListProperty =
      DependencyProperty.Register(
      "BindingList",
      typeof(IObservable<object>),
      typeof(CustomControl),
      new PropertyMetadata(null));
