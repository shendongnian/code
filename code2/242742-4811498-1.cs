    public interface IChangeAware
    {
        event EventHandler<EventArgs> OnChange;
        DateTime ModifiedTime { get; set; }
    }
    public class Student : IChangeAware
    {
        public event EventHandler<EventArgs> OnChange;
        public DateTime ModifiedTime { get; set; }
        public string Name { get; set; }
        public School School
        {
            get { return School; }
            set 
            {
                School = value; 
                if (this.OnChange != null)
                    this.OnChange(this, new EventArgs());
            }
        }
        public Student()
        {
            if (School != null)
                School.OnChange += MySchoolOnChange;
        }
        void MySchoolOnChange(object sender, EventArgs e)
        {
            ModifiedTime = DateTime.Now;
        }
    }
    public class School : IChangeAware
    {
        public event EventHandler<EventArgs> OnChange;
        public DateTime ModifiedTime { get; set; }
        public string SchoolName { get; set; }
        public BindingList<Book> Books { get; set; }
        public School()
        {
            Books = new BindingList<Book>();
            Books.ListChanged += BooksListChanged;
        }
        void BooksListChanged(object sender, ListChangedEventArgs e)
        {
            ModifiedTime = DateTime.Now;
            OnChange(this, new EventArgs());
        }
    }
    public class Book
    {
        public string BookName { get; set; }
    }
