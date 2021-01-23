    class Garage : IEnumerable<Car>
    {
        private List<Car> cars = new List<Car>();
        public Car this[int i]
        {
            get { return cars[i]; }
        }
        public IEnumerator<Car> GetEnumerator() { return cars.GetEnumerator(); }
    }
