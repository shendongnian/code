      var binding = new Binding()
                    {
                       Mode = BindingMode.TwoWay,
                       Source = ((FrameworkElement)sender),
                       Path = new PropertyPath("DataContext")
                    };
