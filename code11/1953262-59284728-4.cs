    public class Book {
      public Book(string bookName) {
        //TODO: Put more validation here if required 
        BookName = bookName != null 
          ? bookName 
          : throw new ArgumentNullException(nameof(bookName));
      }
 
      // Once set in the constructor, this property won't be changed
      public string BookName {get;}  
      public override string ToString() => BookName; 
    }
