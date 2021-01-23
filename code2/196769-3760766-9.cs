    public class AgeComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            return (x == null || y == null) ? x == y : x.Age == y.Age;
        }
    
        public int GetHashCode(Person obj)
        {
            return obj == null ? 0 : obj.Age;
        }
    }  
