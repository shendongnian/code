    public class Card
    {
        public int CardId { get; set; }
        public string Name { get; set; }
        public int? Atk { get; set; }
        public int? Def { get; set; }
        public string Desc {get; set;}
        public int? Level { get; set; }
        public string Type { get; set; }
        public string Attribute { get; set; }
        [DisplayName("Image")]
        public IList<Image> Images { get; set; }
        public IList<Deck> Decks { get; set; }
    }
    public class Image
    {
        public int ImageId { get; set; }
        public int CardId { get; set; }
        public string image_url { get; set; }
        public string image_url_small{ get; set;  }
    }
