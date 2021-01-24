    public class DistinctItemComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            return x.Id == y.Id &&
                x.Name == y.Name;
        }
        public int GetHashCode(Person obj)
        {
            return obj.Id.GetHashCode() ^
                obj.Name.GetHashCode();
        }
    }
