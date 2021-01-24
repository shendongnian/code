    private static Car GetCar(string carName)
    {
        Car car = new Car();
        if (carName== CarCollection.Audi.ToString())
        {
            car.TyreName= "Ceat";
            car.CarName = "Audi X";
        }
        
        return car;
    }
