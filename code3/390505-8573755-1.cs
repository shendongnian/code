    public class Book
    {
        public string id { get; set; }
    }
...
    List<object> entities = new List<object> { new Book { id = "1" }, new Book { id = "2" } };
    List<string> bookIds = new List<string> { "2" };
    IEnumerable<object> books = entities.Where(e => e is Book && bookIds.Contains(((Book)e).id));
