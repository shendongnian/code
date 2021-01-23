    // dp declaration..
    public static readonly DependencyProperty MyDataContextProperty = DependencyProperty.Register(null, "MyDataContext", typeof(object), typeof(MyControl), new PropertyMetadata(MyDataContextChangedCallback));
    // create binding in constructor or initialization.
    Binding binding = new Binding("DataContext");
    BindingOperations.SetBinding(this, MyDataContextProperty, binding);
