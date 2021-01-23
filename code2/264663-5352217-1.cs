    using System;
    
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
    
        int Value
        {
            get;
            private set;
        }
    
        Card(Suit suit, int value)
        {
            Suit = suit;
            Value = value;
        }
    
        private const string[] valsToString = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
    
        bool IsValid()
        {
            return Value >= 2 && Value <= 14;
        }
    
        override string ToString()
        {
            return string.Format("{0} of {1}", valsToString[Value], Suit);
        }
    }
