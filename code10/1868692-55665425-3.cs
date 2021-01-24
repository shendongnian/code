    namespace SimpleDropDownList.Models
    {
        [NotMapped]
        public class AuthorViewModel
        {
            //Property to hold the list of authors in the GET
            public IEnumerable<SelectListItem> AuthorOptions { get; set; }
    
            //Property to bind the selected author used in the POST
            public List<int> SelectedAuthorIds { get; set; }
        }
    }
