    class Book : Publication
    {
       // .. Your code...
       public override string ToString()
       {
           return this.Title + " by " + this.AuthorFirstName + " " + this.AuthorLastName;
       }
