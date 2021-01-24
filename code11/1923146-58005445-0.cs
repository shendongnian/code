    ChartViewModel.DataItem item1 = new ChartViewModel.DataItem();
    item1.Value1 = 10;
    
    CartesianCustomLineAnnotation c1 = new CartesianCustomLineAnnotation();
    c1.Stroke = new SolidColorBrush(Colors.Red);
    c1.StrokeThickness = 2;
    
    Binding myBinding = new Binding();
    myBinding.Source = item1;
    myBinding.Path = new PropertyPath("Value1");
    myBinding.Mode = BindingMode.OneWay;
    BindingOperations.SetBinding(c1, CartesianCustomLineAnnotation.VerticalFromProperty, myBinding);
    
    OhlcChart.Annotations.Add(c1);
