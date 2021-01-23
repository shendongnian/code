    PrescriberPage01 page = new PrescriberPage01();
    page.Visibility = Visibility.Collapsed;
    Binding myBinding = new Binding("SelectedProduct");
    myBinding.Mode = BindingMode.TwoWay;
    myBinding.Source = this.SelectedProduct;
    page.SetBinding(PrescriberPage01.MySelectedProductProperty, myBinding);
    LayoutRoot.Children.Add(page);
