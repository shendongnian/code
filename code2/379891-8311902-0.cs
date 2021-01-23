    private void FieldLayoutInitialized(object sender, FieldLayoutInitializedEventArgs e) {
      var fieldlayout = e.FieldLayout;
    
      UnboundField field = new UnboundField();
      field.Name = "Testfield";
      fieldlayout.Fields.Add(field);
    
      var multiBinding = new MultiBinding();
      multiBinding.Mode = BindingMode.OneWay;
      multiBinding.Converter = new MultiBindingConverter(); // implement IMultiValueConverter
      multiBinding.Bindings.Add(new Binding() { Path = new PropertyPath("A1"), Mode = BindingMode.OneWay });
      multiBinding.Bindings.Add(new Binding() { Path = new PropertyPath("A2"), Mode = BindingMode.OneWay });
            
      field.Binding = multiBinding;
    }
