    public Page Page { get; set; }
   
----
    this.Loaded += delegate
    {
        Page = (Application.Current.RootVisual as Frame).Content as Page;
    };
