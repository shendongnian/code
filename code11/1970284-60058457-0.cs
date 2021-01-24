    checkboxHeaderFactory.SetBinding(ToggleButton.IsCheckedProperty, 
        new Binding(nameof(ViewModel.AllSelected))
        { 
            UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
            Source = DataContext
        });
