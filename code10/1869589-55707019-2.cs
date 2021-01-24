    namespace SimpleDropDownList.Models
        {
            [NotMapped]
            public class AuthorViewModel
            {
                //Property to hold the list of authors in the GET
                public IEnumerable<SelectListItem> AuthorOptions { get; set; }
        
                //Property to bind the selected author used in the POST
                public List<int> SelectedAuthorIds { get; set; }
                // Added this property to link back to Book class
                public Book Book { get; set; }
            }
        }
