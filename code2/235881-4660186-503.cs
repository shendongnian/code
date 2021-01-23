    public class Person {
        public int Age { get; set; }
    }
    public class Book {
        public Person Author { get; set; }
    }
    public class Example {
        public void Foo() {
            Book b1 = new Book();
            int authorAge = b1.Author.Age; // You never initialized the Author property.
                                           // there is no Person to get an Age from.
        }
    }
