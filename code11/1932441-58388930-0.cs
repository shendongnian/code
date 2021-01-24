    public bool Equals(BaseCard other)
    {
        if (other == null)
            return false;
        return this.Color == other.Color
               && this.Number == other.Number
    }
     public override bool Equals(Object obj)
     {
         if (obj == null)
             return false;
         BaseCard cardOther = obj as BaseCard;
         if (cardOther == null)
             return false;
         else
             return Equals(cardOther);
    }
    public override int GetHashCode()
    {
        return this.Number; // could be something else
    }
    public static bool operator == (BaseCard card1, BaseCard card2)
    {
        if (((object)card1) == null || ((object)card2) == null)
            return Object.Equals(card1, card2);
        return card1.Equals(card2);
    }
    public static bool operator != (BaseCard card1, BaseCard card2)
    {
        if (((object)card1) == null || ((object)card2) == null)
            return ! Object.Equals(card1, card2);
        return ! (card1.Equals(card2));
    }
