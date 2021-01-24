    public class Book {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime DatePublished { get; set; }
    }
    
    //Action method on HomeController
    public ActionResult UpdateProducts(ICollection<Book> books) {
        return View(books);
    }
