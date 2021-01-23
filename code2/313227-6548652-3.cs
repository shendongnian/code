    PrescriberPage01 page = new PrescriberPage01();
    page.Visibility = Visibility.Collapsed;
    Binding myBinding = new Binding("SelectedProduct");
    myBinding.Mode = BindingMode.TwoWay;
    myBinding.Source = this; // or whatever object carrying the property
                             // "SelectedProduct" that you bind against.
    page.SetBinding(PrescriberPage01.SelectedProduct, myBinding);
    LayoutRoot.Children.Add(page);
