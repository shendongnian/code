    enum Suit
    {
        Clubs,
        Hearts,
        Diamonds,
        Spades
    }
    class Card
    {
        Suit Suit
        {
            get;
            private set;
        }
        char Value
        {
            get;
            private set;
        }
        Card(Suit suit, char value)
        {
            Suit = suit;
            Value = value;
        }
        private const char[] validVals = new char[] { '2', '3', '4', '5', '6', '7', '8', '9', 'J', 'Q', 'K', 'A' };
        bool IsValid()
        {
            return validVals.Contains(Value);
        }
    }
