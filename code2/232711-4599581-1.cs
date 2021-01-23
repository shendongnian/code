    namespace StackOverflow_4599533
    {
        public class Deck
        {
            private static Random sRand = new Random();
            private List<Card> mCards = new List<Card>();
            public Deck()
            {
                Shuffle();
            }
            public void Shuffle()
            {
                mCards.Clear();
                foreach (char suit in "DSCH") // Diamond, Spade, Clover, Heart
                {
                    foreach (char rank in "1234567890JQK")
                    {
                        mCards.Add(new Card(rank, suit));
                    }
                }
            }
            public Card DealCard()
            {
                int cardIndex = sRand.Next(mCards.Count);
                Card card = mCards[cardIndex];
                mCards.Remove(card);
                return card;
           }
        }
        public class Card
        {
            public char r, s;
            public Card(char rank, char suit)
            {
                r = rank;
                s = suit;
            }
            public override string ToString()
            {
                return "" + s + r;
            }
        }
    
        public class Hand
        {
            public Card c1, c2;
    
            public Hand(Card one, Card two)
            {
                c1 = one;
                c2 = two;
            }
            public override string ToString()
            {
                return "C1: " + c1 + " C2: " + c2;
            }
        }
    
        public class Dealer
        {
            private Deck mDeck;
    
            public Dealer(Deck deck)
            {
                mDeck = deck;
            }
    
            public Hand DealHand()
            {
                return new Hand(mDeck.DealCard(), mDeck.DealCard());
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Deck deck = new Deck();
                Dealer dealer = new Dealer(deck);
                Hand hand1 = dealer.DealHand();
                Hand hand2 = dealer.DealHand();
                Console.WriteLine(hand1);
                Console.WriteLine(hand2);
    
                deck.Shuffle();
                hand1 = dealer.DealHand();
                hand2 = dealer.DealHand();
                Console.WriteLine(hand1);
                Console.WriteLine(hand2);
            }
        }
    }
