    public class Card : IComparble<T>
    {
        public string ID;
        public string Name;
    
        public int CompareTo(Card other) 
        {
            if (null == other)
                return 1;
    
            return Id.CompareTo(other.Id);
        }
    }
