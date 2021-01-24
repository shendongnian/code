    foreach (var appliance in appliances)
    {
        if (appliance.GetType() == typeof(VacCleaner))
            vacuumGrid.Items.Add(appliance);
        if (appliance.GetType() == typeof(FoodProcessor))
            foodGrid.Items.Add(appliance);
        if (appliance.GetType() == typeof(WashingMachine))
            washingGrid.Items.Add(appliance);
        appliance.PropertyChanged += AppliancePropertyChanged;
    }
    private void AppliancePropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "ChBox")
        {
            // do something
        }
    }
