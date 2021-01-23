    public class Book {
        public string Title { get; set; }
    }
    public class Example {
        public void Foo() {
            Book b1;
            string title = b1.Title; // You never initialized the b1 variable.
                                        // there is no book to get the title from.
        }
    }
