    private void Grid_Loaded(object sender, RoutedEventArgs e)
    {
        SetBindings();
    }
    private void SetBindings()
    {
        foreach (UIElement element in grid1.Children)
        {
            if (element is CustCntr)
            {
                CustCntr custCntr = element as CustCntr;
                foreach (MyEntity myEntity in MyCollection)
                {
                    if (custCntr.Name == myEntity.Name)
                    {
                        Binding property1Binding = new Binding("Property1");
                        property1Binding.Source = myEntity;
                        property1Binding.Mode = BindingMode.TwoWay;
                        custCntr.SetBinding(CustCntr.Property1Property, property1Binding);
                        break;
                    }
                }
            }
        }
    }
