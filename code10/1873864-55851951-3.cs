    public class Card {
      public Card(string name, int value, Suit suit, Bitmap image) {
        Name = name;
        Value = value;
        Suit = suit;
        Image = image;
      }
      public string Name { get; private set; }
      public Suit Suit { get; private set; }
      public int Value { get; private set; }
      public Bitmap Image { get; private set; }
    }
    
    public enum Suit {
      Hearts = 1,
      Spades = 2,
      Clubs = 3,
      Diamonds = 4
    }
