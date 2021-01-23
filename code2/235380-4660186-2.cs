    public class Book {
        public Person Author { get; set; }
    }
    Book b1 = new Book();
    int authorAge = b1.Author.Age; // You never initialized the Author property.
                                   //  there is no Person to get an Age from.
