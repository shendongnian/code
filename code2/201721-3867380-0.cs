    public class Game : IGame
    {       
        public List<IPlayer> Players
        {
            get { return _players; }
        }
    }
    public class Player : IPlayer
    {
        public IHand Hand { get; internal set; }
    }
    public class Hand : IHand
    {
        public List<Card> FaceDownCards { get; internal set; }
        public List<Card> FaceUpCards { get; internal set; }
        public List<Card> InHandCards { get; internal set; }
    }
