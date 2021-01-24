    public bool Equals(BaseCard other)
    {
        if (other == null)
            return false;
        /*
         * Add as many property comparison as needed
         * This will define what makes 2 objects equal
         */
        return this.Color == other.Color
               && this.Number == other.Number;
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
    /*
     * This allows you to do card.PersonalCardObject == CurrentCard
     * without comparing references
     * This is optional and not necessarily wanted
     */
    public static bool operator == (BaseCard card1, BaseCard card2)
    {
        if (((object)card1) == null || ((object)card2) == null)
            return Object.Equals(card1, card2);
        return card1.Equals(card2);
    }
    // Same as above, this is optional and not necessarily wanted
    public static bool operator != (BaseCard card1, BaseCard card2)
    {
        if (((object)card1) == null || ((object)card2) == null)
            return ! Object.Equals(card1, card2);
        return ! (card1.Equals(card2));
    }
