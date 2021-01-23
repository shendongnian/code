    class Garage : IEnumerable<Car>
    {
        private List<Car> cars = new List<Car>();
        public Car this[int i]
        {
            get { return cars[i]; }
        }
        // For IEnumerable<Car>
        public IEnumerator<Car> GetEnumerator() { return cars.GetEnumerator(); }
        // For IEnumerable
        public IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
    }
