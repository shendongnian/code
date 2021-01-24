    var vehicles = new List<IVehicle>
    {
    	new Car
    	{
    		Make = VehicleMake.BMW,
    		MakeYear = 2020,
    		Rental = new Rental { IsRented = true }
    	},
    	new Car
    	{
    		Make = VehicleMake.Toyota,
    		MakeYear = 2000,
    		Rental = new Rental { IsRented = false }
    	},
    	new Truck
    	{
    		Make = VehicleMake.Nissan,
    		MakeYear = 2015,
    		Rental = new Rental { IsRented = false }
    	}
    };
    
    
    foreach (var vehicle in vehicles)
    {
    	Console.Write($"{vehicle.GetType().Name}\t");
    	Console.Write($"{vehicle.Make.ToString()}\t");
    	Console.Write($"{vehicle.MakeYear.ToString()}\t");
    	Console.Write($"{vehicle.Fuel.ToString()}\t");    
    
    	if (vehicle.Rental?.IsRented == true)
    	{
    		Console.Write("rented");
    	}
    	else
    	{
    		Console.Write("not rented");
    	}
    
    	Console.WriteLine();
    }
