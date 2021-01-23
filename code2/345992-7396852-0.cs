    System.Windows.Data.Binding bind = new System.Windows.Data.Binding();       
    bind.Source = this;       
    bind.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;       
    bind.Path = new PropertyPath("Value");       
    bind.Mode = BindingMode.OneWay;
    DepOb.SetBinding(DepObClass.WidthOrSomethingProperty, bind);
