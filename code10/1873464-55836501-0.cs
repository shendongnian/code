    public class CarEqualityComparer : IEqualityComparer<Car>
    {
        public bool Equals(Car x, Car y)
        {
            return x.Id == y.Id;
        }
        public int GetHashCode(Car obj)
        {
            return obj.Id.GetHashCode();
        }
    }
