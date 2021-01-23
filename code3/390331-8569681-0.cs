    IEnumerable<Car> _cars = repository.GetAllCars();
    ShowMeAll(_cars.OrderBy(car => car.Make));
    
    IEnumerable<House> _houses = repository.GetAllHouses();
    ShowMeAll(_houses.OrderBy(house => house.SquareFootage));
