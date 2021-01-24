    public class Card : IComparable<Card>
    {
        public string ID;
        public string Name;
    
        public int CompareTo(Card other) 
        {
            if (null == other)
                return 1;
    
            // string.Compare is safe when Id is null 
            return string.Compare(this.Id, other.Id);
        }
    }
