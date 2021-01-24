    public class Course
    {
       //Rest of your properties goes here
       [ForeignKey(nameof(Author))]
       public int AuthorId {get; set;}
       public virtual Author Author {get; set;}
    }
    public class Author 
    {
       //Rest of your properties goes here
       public virtual ICollection<Course> Courses {get; set;}
    }
