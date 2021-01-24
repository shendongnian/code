    public class CardStack
    {
        private readonly List<Card> _cardList;
        public CardStack()
        {
            _cardList = getCardList();
        }
        private static List<Card> getCardList()
        {
            var localList = new List<Card>();
            foreach (CardType type in Enum.GetValues(typeof(CardType)))
            {
                foreach (CardColor color in Enum.GetValues(typeof(CardColor)))
                {
                    var cardObject = new Card(){Type = type, Color = color};
                    localList.Add(cardObject);
                }
            }
            return localList;
        }
    }
    }
