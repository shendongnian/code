    public class NewBook
    {
        public string BookText {get;set;}
        public Library ParentLibrary {get;set;}
    }
    
    public class BetterLibrary
    {
        private List<NewBook> books = new List<NewBook>();
        
        public bool AddNewBookToLibrary(NewBook bookToAdd)
        {
            books.Add(bookToAdd);
            booktoAdd.ParentLibrary = this;
        }
    }
