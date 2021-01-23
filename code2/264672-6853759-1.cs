    public class Card
    {
        short id;
        public Card(string zFile)
        {
            this.id = Convert.ToInt16(zFile.Split('.')[0].Trim());
            this.Rank = new Rank(id);
            this.Suit = new Suit(id);
        }
        public override string ToString()
        {
            if (Suit.Flag == 5)
                return Suit.Name;
            return string.Concat(Rank.Name, " of ", Suit.Name);
        }
        public override int GetHashCode()
        {
            return id;
        }
        public Rank Rank { get; private set; }
        public Suit Suit { get; private set; }
        public static Card GetGreaterRank(Card value1, Card value2)
        {               
            return  (value1.Rank >= value2.Rank) ? value1 : value2;                        
        }
        public static bool CompareRank(Card value1, Card value2)
        {
            return (value1.Rank.Flag == value2.Rank.Flag);
        }
        public static bool CompareSuit(Card value1, Card value2)
        {
            return (value1.Suit.Flag == value2.Suit.Flag);
        }
    };    
    public abstract class Info
    {
        protected Info(short cardID)
        {
            Flag = SetFlag(cardID);            
        }
        protected string SetName(short cardID, params string[] names)
        {
            for (int i = 0; i < names.Length; i++)
            {
               if (Flag == (i + 1))
                  return names[i];
            }
            return "Unknown";
        }
   
        protected abstract byte SetFlag(short cardID);
        public static implicit operator byte(Info info)
        {
            return info.Flag;
        }
        public byte Flag { get; protected set; }
        public string Name { get; protected set; }
    };
    public class Rank : Info
    {
        internal Rank(short cardID) : base(cardID) 
        { 
            string name = SetName(cardID, "A","2","3","4","5","6","7",
                   "8","9","10","J","Q","K","Little Joker","Big Joker","Wild");
            Name = (name == "Unknown") ? string.Concat(name, " Rank") : name;
        }
        
        protected override byte SetFlag(short cardID)
        {
            return Convert.ToByte(cardID.ToString().Remove(0, 1));
        }        
    };
    public class Suit : Info
    {
        internal Suit(short cardID) : base(cardID) 
        { 
            string name = SetName(cardID,"Clubs","Diamonds","Hearts","Spades");
            Name = (name == "Unknown") ? string.Concat(name, " Suit") ? name;
        }
               
        protected override byte SetFlag(short cardID)
        {
            return Convert.ToByte(cardID.ToString().Remove(1));
        }
    };
