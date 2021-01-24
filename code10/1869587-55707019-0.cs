    namespace SimpleDropDownList.Models
    {
        public class Book
        {
            [Key]
            public int BookID { get; set; }
            [StringLength(255)]
            [Display(Name = "Book Title")]
            public string Title { get; set; }
            public int AuthorID { get; set; }
            public Author Author { get; set; }
            // Removed this link and added property to AuthorViewModel class
            // public AuthorViewModel AuthorViewModel { get; set; }
        }
    }
