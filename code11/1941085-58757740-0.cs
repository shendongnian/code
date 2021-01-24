    public class Board
    {
        public int BoardId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<BoardList> Lists { get; set; } = new List<BoardList>();
    }
    
    public class BoardList
    {
        public int BoardListId { get; set; }
        public string Name { get; set; }
        public Virtual ICollection<Card> Cards { get; set; } = new List<Card>();
    }
    
    public class Card
    {
        public long CardId { get; set; }
        public CardType Type { get; set; }
    }
