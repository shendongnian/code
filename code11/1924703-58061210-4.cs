    public IEnumerable<Card> GetCardList()
    {
        foreach (CardType type in Enum.GetValues(typeof(CardType)))
        {
            foreach (CardColor color in Enum.GetValues(typeof(CardColor)))
            {
                yield return new Card(type,color);
            }
        }
    }
