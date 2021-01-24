    public class PersonByNameComparer : IEqualityComparer<Peron>
    {
        public bool Equals(Person p1, Persion p2)
        {
            return p1.Name == p2.Name;
        }
        public int GetHashCode(Person p)
        {
            return p.Name.GetHashCode();
        }
    }
