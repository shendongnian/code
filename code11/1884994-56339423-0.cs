    public class Book 
    {
      public Guid BookId { get;set; }
      public string BookName { get;set; }
      [ForeignKey("Category")]
      public Guid CategoryId { get;set; } // <-- Here CategoryId instead of CategoryCode
      public Category Category { get;set; }
    }
