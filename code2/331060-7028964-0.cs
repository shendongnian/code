    public class Note
    {
        public int Id { get; set; }
        public int? CategoryId { get { return Category == null ? (int?)null : Category.Id; } }
        public virtual Category Category { get; set; }
    }
