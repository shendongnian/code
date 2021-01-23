    class CarComparer : IList<Car>, IEqualityComparer<List<Car>>
    {
        public bool Equals(List<Car> x, List<Car> y)
        {
            return return object.Equals(x.GetHashCode(),y.GetHashCode());
        }
        public int GetHashCode(List<Car> obj)
        {
            return _runningHash;
        }
        public void Insert(int index, Car item)
        {
            // Update _runningHash here
            throw new NotImplementedException();
        }
        public void RemoveAt(int index)
        {
            // Update _runningHash here
            throw new NotImplementedException();
        }
        // More IList<Car> Overrides ....
    }
