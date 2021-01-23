    private void DealCards(Func<Hand, List<Card>> handProjection)
    {
        for (int i = 0; i < 3; i++)
        {
            foreach (var player in Players)
            {
                List<Card> cards = handProjection(player.Hand);
                if (cards.Count < 3)
                {
                    if (Deck.Count > 0) 
                    {
                        cards.Add(Deck.TakeTopCard());
                    }
                }
            }
        }
    }
    public void DealStartingCards()
    {
        DealCards(hand => hand.FaceDownCards);
        DealCards(hand => hand.FaceUpCards);
        DealCards(hand => hand.InHandCards);
    }
