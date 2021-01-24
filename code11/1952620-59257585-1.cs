    public static class ExampleMapperClass //or w/e you want to call it{
       
      public static LibaryCardField ToEntity(this LibraryCardFieldDto lbf){
          return new LibraryCardField{
            Id = lbf.Id,
            Book = lbf.book.ToEntity(),//create another extension method for this one
            LibraryCard  = LibraryCardDto.ToEntity(),//same here
            IssueDate = lbf.issueDate,
            ReturnDate = lbf.returnDate
          };
      }  
    }
