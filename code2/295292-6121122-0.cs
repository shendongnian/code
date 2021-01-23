    public class SchoolClass // avoid collision with the "class" keyword
    {
        public SchoolClass()
        {
            this.Students = new List<Student>();
        }
    
        public List<Student> Students
        {
           get; 
           private set;
        }
    }
    
    public class Student
    {
        public Student()
        {
            this.Books= new List<Book>();
        }
    
        public List<Book> Books
        {
           get; 
           private set;
        }
    
        public string Name
        {
            get;
            set;
        }
    }
    
    public class Book
    {
        public string Name
        {
            get;
            set;
        }
    
        public string Author
        {
            get;
            set;
        }
    
        public string Publisher
        {
            get;
            set;
        }
    }
