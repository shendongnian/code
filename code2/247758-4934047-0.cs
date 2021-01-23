    [TestMethod]
    public void TestRandomPicking()
    {
        Random random = new Random(1);
        Deck deck = new Deck(random);
        Assert.AreEqual(3, deck.PickCard().Value);
        Assert.AreEqual(1, deck.PickCard().Value);
        Assert.AreEqual(5, deck.PickCard().Value);
    }
    public class Deck
    {
        public Deck()
        {
            _randomizer = new Random();
        }
        public Deck(Random randomizer)
        {
            _randomizer = randomizer; 
        }
        Random _randomizer;
        private List<Card> _cards = new List<Card>
                                        {
                                            new Card {Value = 1},
                                            new Card {Value = 2},
                                            new Card {Value = 3},
                                            new Card {Value = 4},
                                            new Card {Value = 5},
                                            new Card {Value = 6},
                                            new Card {Value = 7},
                                            new Card {Value = 8},
                                            new Card {Value = 9},
                                            new Card {Value = 10}
                                        };
        private List<Card> Cards { get { return _cards; } }
        public Card PickCard()
        {
            return Cards[_randomizer.Next(0, Cards.Count - 1)];
        }
    }
    public class Card
    {
        public int Value { get; set; }
    }
