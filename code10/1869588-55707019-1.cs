    namespace SimpleDropDownList.Models
    {
        public class Author
        {
            [Key]
            public int AuthorID { get; set; }
            [Display(Name = "First Name")]
            [StringLength(50)]
            public string FirstName { get; set; }
            [Display(Name = "Last Name")]
            [StringLength(50)]
            public string LastName { get; set; }
            public ICollection<Book> Books { get; set; } = new List<Book>();
        }
    }
