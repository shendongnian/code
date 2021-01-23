    [OperationContract]
    [WebGet(ResponseFormat=WebMessageFormat.Json)]
    public string GetCar()
    {
        // You will probably build this up from your databas
        var cars = new CarCollection { CarList = new List<Car>() {
            new Car { CarName = "x1", CarId = "id1" },
            new Car { CarName = "x2", CarId = "id2" },
            new Car { CarName = "x3", CarId = "id3" },
        }};
    
        return cars;
    }
