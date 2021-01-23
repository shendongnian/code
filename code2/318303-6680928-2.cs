    class CarComparer : IList<Car>, IEquatable<CarComparer>
    {
        public bool Equals(CarComparer other)
        {
            return object.Equals(GetHashCode(),other.GetHashCode());
        }
        public override int GetHashCode()
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
