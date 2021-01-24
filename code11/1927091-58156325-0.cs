    [HttpPost("createMultiple")]
    public IActionResult CreateCars(List<Car> cars) {}
    
    [HttpPost()]
    public IActionResult CreateCar(Car car) {}
