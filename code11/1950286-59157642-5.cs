    private static Car GetCar(string carName)
    {
        Car car = new Car();
        if (carName== CarCollection.Audi.ToString())
        {
            car.TyreName= "Ceat";
            car.CarName = "Audi X";
        }
        else if (carName== CarCollection.BMW.ToString())
        {
            car.TyreName = "ABCD";
            car.CarName = "BMW Y";
        }
       
        return car;
    }
