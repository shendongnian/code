    public class Test
    {
        private List<Car> cars;
        public void PopulateDataSource()
        {
            cars = new List<Car>
            {
                new Car("Ford", "Mustang", 1967),
                new Car("Shelby AC", "Cobra", 1965),
                new Car("Chevrolet", "Corvette Sting Ray", 1965)
            };
            _dgCars.DataSource = cars;
        }
        public void IterateThroughCars()
        {
            foreach (Car car in cars) // Loop through List with foreach
            {
                ...
            }
        }
    }
