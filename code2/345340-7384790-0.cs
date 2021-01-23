    public class NewsEntry
    {
        public int NewsEntryId { get; set; }
        public string Title { get; set; }
        public string ShortText { get; set; }
        public string Text { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime UnpublishDate { get; set; }
        public int NewsCategoryId { get; set; }
        public virtual NewsCategory NewsCategory { get; set; }
    }
