    IEnumerable<Car> carList = listCars.SelectMany(cars => cars);
    
    List<Car> repeatedCars = new List<Car>();
    
    int length = listCars.Count;
    
    foreach (Car c in cars1)
    {
        int numberRepeats = carList.Count(car => car.Name == c.Name);
        if (numberRepeats == length)
        {
            repeatedCars.Add(c);
        }
    }
