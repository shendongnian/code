    class Book
    {
        public Book(string id, string name, string author)
        {
            ID = id;
            Name = name;
            Author = author;
        }
        public string ID { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
    }
    List<Book> listBook = new List<Book>();
            listBook.Add(new Book( "103", "Code Complete", "Steve MC"  ));
            listBook.Add(new Book("101", "Effective C++", "Scott Meyers"));
            listBook.Add(new Book("102", "CLR Via C#", "Jeff Prosise"));
            listBook.Sort(
                delegate(Book a, Book b) 
                {
                    return a.ID.CompareTo(b.ID);
                });
