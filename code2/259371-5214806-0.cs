    public FixedSizeList<Card> CardList
    {
        get { return _cardList; }
        set { _cardList = value; }
    }
    
    private FixedSizeList<Card> _cardList = new FixedSizeList<Card>(99999999);
