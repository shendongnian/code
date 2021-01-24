     public static Car GetCarDetails(string carName)
        {
            List<Car> cars = new List<Car>()
            {
                new Car(){ Name = CarName.Audi, TyreName = "CEAT", YearOfModel=2018},
                new Car(){ Name = CarName.BMW, TyreName = "ABCD", YearOfModel=2019}
            };
            return cars.Where(car => car.Name.ToString().Equals(carName)).Select(car => car).FirstOrDefault();
        }
