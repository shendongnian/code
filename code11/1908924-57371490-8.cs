    public sealed class CardByIdComparer : IComparer<Card> 
    {
        public int Compare(Card x, Card y) 
        {
            if (object.ReferenceEquals(x, y))
                return 0;
            else if (null == x)
                return -1;
            else if (null == y)
                return 1;
            else
                return string.Compare(x.Id, y.Id);
        }
    }
