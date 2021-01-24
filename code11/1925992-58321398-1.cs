     Binding theBinding  = new Binding();
     theBinding.Mode = BindingMode.TwoWay;
     theBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
     theBinding.ValidatesOnDataErrors = true;
    
     DataGridComboBoxColumn colSuggestionList = new DataGridComboBoxColumn();
    
     // theCollection is Collection<string>     
     colSuggestionList.ItemsSource = theCollection;
    
    
     colSuggestionList.SelectedValueBinding = theBinding;
     colSuggestionList.Visibility = Visibility.Visible;   
     colSuggestionList.EditingElementStyle = dgMainTemplate.FindResource("ComboBoxEditingStyle") as Style;
     
     colSuggestionList.EditingElementStyle = dgMainTemplate.FindResource("ComboBoxEditingStyle") as Style;
     colSuggestionList.ElementStyle = dgMainTemplate.FindResource("TextBlockComboBoxStyle") as Style;
     // dgMainTemplate is wpf DataGrid                      
     dgMainTemplate.Columns.Add(colSuggestionList);
