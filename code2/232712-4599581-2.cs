    public interface Hand
    {
        Card C1
        {
            get;
        }
        Card C2
        {
            get;
        }
    }
    public interface Dealer
    {
         Hand DealHand();
    }
    public class SpecialDealer : Dealer
    {
        private Deck mDeck;
        private class HandImpl : Hand
        {
            private Card mC1;
            private Card mC2;
            public Card C1
            {
                get
                {
                    return mC1;
                }
            }
            public Card C2
            {
                get
                {
                    return mC2;
                }
            }
            public HandImpl(Card c1, Card c2)
            {
                mC1 = c1;
                mC2 = c2;
            }
            public override string ToString()
            {
                return C1 + " " + C2;
            }
        }
        public SpecialDealer(Deck deck)
        {
            mDeck = deck;
        }
        public Hand DealHand()
        {
            return new HandImpl(mDeck.DealCard(), mDeck.DealCard());
        }
    }
