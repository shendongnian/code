    public class Book
    {
      public int Id { get; set; }
      public string Title { get; set; }
      public int LibraryId { get; set; }
      public Library Library {get;set;} //navigation property to Library
      public Bookshelf Bookshelf { get; set; }
      public Bookshelf Bookshelf {get;set;} //navigation property to Bookshelf
    }
