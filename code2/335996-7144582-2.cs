    class Book : IComparable
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
        public int CompareTo(object obj)
        {
            return ID.CompareTo(((Book)obj).ID);
        }
    }
