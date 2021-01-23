    public class Book
    {
        private string title;
        private string author;
        private DateTime datePublished;
        private bool isModified = false;
        public string Title
        {
            get { return title; }
            set { title = value; isModified = true; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; isModified = true; }
        }
        public DateTime DatePublished
        {
            get { return datePublished; }
            set { datePublished = value; isModified = true; }
        }
        public bool IsModified
        {
            get { return isModified; }
        }
    }
