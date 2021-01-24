    private int HouseholdWith(List<Dictionary<string, string[]>> cars, string car1)
    {
    	return cars.Count(household => household["car"].Any(c => c == car1));
    }
    
    private int HouseholdWith(List<Dictionary<string, string[]>> cars, string car1, string car2)
    {
    	return cars.Count(household => household["car"].Any(c => c == car1) && household["car"].Any(c => c == car2));
    }
    
    private int HouseholdWithOnly(List<Dictionary<string, string[]>> cars, string car)
    {
    	return cars.Count(household => household["car"].All(c => c == car));
    }
