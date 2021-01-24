      public class Author
                {
                public int AuthorId {get;set;}
                public string AuthorName {get;set;}
                public int AuthorAge {get;set;}
                public virtual List<Book> Books {get;set;}
                }
    
    
    
     public partial class Book
        {
               public int BookId {get;set;}
               public string BookName {get;set;}
               public int AuthorId {get;set;}
               public virtual Author Author {get;set;}
    
        }
    
     public partial class Book
       {
         public string AuthorName {get{return Author.AuthorName;}}
         public int AuthorAge {get{return Author.AuthorAge;}}
       }
