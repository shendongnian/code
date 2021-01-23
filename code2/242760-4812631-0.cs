    List<Car> lstCar = new List<Car>();
    lstCar.Add(new Car() { Make = "tootay", Model = "camry", VechicleId = 1 });
    lstCar.Add(new Car() { Make = "honda", Model = "civic", VechicleId = 2 });
    
    VehicleConverter(lstCar);
    
    public void VehicleConverter(IEnumerable<MyBaseClass> vehicles)
    {
    	var found = vehicles.Where(v => v.VechicleId == 123);
    }
