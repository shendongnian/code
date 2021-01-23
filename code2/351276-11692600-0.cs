    // List of Custom Objects - Results in inconsistent behavior
    ObservableCollection<VehicleData> vehicleList = new ObservableCollection<VehicleData>();
    for (int i = 0; i < 80; i++)
    {
    	vehicleList.Add(new VehicleData
    	{
    		ID = i,
    		Name = string.Format("Vehicle {0}", i)
    	});
    }
    ComboBoxVehicles.DisplayMemberPath = "Name";
    ComboBoxVehicles.ItemsSource = vehicleList;
