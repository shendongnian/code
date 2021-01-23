    [DataContract]
    public class Book
    {
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Author { get; set; }
        [DataMember]
        public Publisher Publisher { get; set; }
    }
    [DataContract]
    public class Publisher
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Location { get; set; }
        [DataMember]
        public short Founded { get; set; }
    }
    [ServiceContract]
    public interface ILibraryService
    {
        [OperationContract]
        Book GetBook();
    }
    public class LibraryService : ILibraryService
    {
        public Book GetBook()
        {
            return new Book
            {
                Title = "Animal Farm",
                Author = "George Orwell",
                Publisher = new Publisher
                {
                    Name = "Secker and Warburg",
                    Location = "London",
                    Founded = 1910,
                }
            };
        }
    }
