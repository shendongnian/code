    public class AnimalNameColourComparer : IEqualityComparer<Animal>
    {
        public bool Equals(Animal a, Animal b)
        {
            return a.Name == b.Name &&
                   a.Color == b.Color
        }
        public int GetHashCode(Animal a)
        {
            return a.Name.GetHashCode() ^ a.Color.GetHashCode();
        }
    }
