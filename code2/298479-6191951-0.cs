    public abstract class Deck
        {
              public int NumberOfCards{get; private set;}
              
              public IEnumerable<Card> Cards {get; private set;}
        
              public void Shuffle()
              {
                  Cards = RandomizeCards();
              }
        
              protected abstract IEnumerable<Card> CreateCardList();
        
        }
        
        public class PokerDeck
        {
             public PokerDeck()
             {
                  NumberOfCards = 52;
                  Cards = CreateCardList();
             }
        }
        
        public class MagicDeck
        {
             public MagicDeck()
             {
                 NumberOfCards = 10000; // have no idea
                  Cards = CreateCardList();
             }
        }
