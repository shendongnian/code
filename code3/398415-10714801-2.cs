    Dim newBind As Binding = New Binding("LinktoCommonOutputBus")
    newBind.Mode = BindingMode.OneWay
    factory1.SetValue(ComboBox.ItemsSourceProperty, dictionary)
    factory1.SetValue(ComboBox.NameProperty, name)
    factory1.SetValue(ComboBox.SelectedValuePathProperty, "Key")
    factory1.SetValue(ComboBox.DisplayMemberPathProperty, "Value")
    factory1.SetBinding(ComboBox.SelectedValueProperty, newBind)
