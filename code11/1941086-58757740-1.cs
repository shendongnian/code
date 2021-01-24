    public class BoardDTO
    {
        public int BoardId { get; set; }
        public string Name { get; set; }
        public IEnumerable<BoardListDTO> Lists { get; set; }
    }
    
    public class BoardListDTO
    {
        public int BoardListId { get; set; }
        public string Name { get; set; }
        public IEnumerabe<CardDTO> Cards { get; set; }
    }
    
    public class CardDTO
    {
        public long CardId { get; set; }
        public CardType Type { get; set; }
    }
