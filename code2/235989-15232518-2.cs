    class Book {
        public string Name { get; set; }
    }
    class Car { }
    Car mycar = new Car();
    Book mybook = mycar as Book;   // Incompatible conversion --> mybook = null
    Console.WriteLine(mybook.Name);   // NullReferenceException
