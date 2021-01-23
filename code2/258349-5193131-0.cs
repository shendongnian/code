	// Get all the cars
	List<Car> cars = context.Cars.ToList();
	// Clear the DataViewGrid
	uiGrid.Rows.Clear();
	// Populate the grid
	foreach (Car car in cars)
	{
		// Add a new row
		int rowIndex = uiGrid.Rows.Add();
		DataGridViewRow newRow = uiGrid.Rows[rowIndex];
		
		// Populate the cells with data for this car
		newRow.Cells["Make"].Value = car.Make;
		newRow.Cells["Model"].Value = car.Model;
		newRow.Cells["Description"].Value = car.Description;
		
		// If the price is not null then add it to the price column
		if (car.Price != null)
		{
			newRow.Cells["Price"].Value = car.Price;
		}
		else
		{
			newRow.Cells["Price"].Value = "No Price Available";
		}
	}
