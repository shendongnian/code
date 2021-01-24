    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    namespace CmsShop.Models.Data
    {
        [Table("tblPages")]
        public class PageDTO
        {
            [Key]
            public int Id { get; set; }
            public string Title { get; set; }
            public string Slug { get; set; }
            public string Body { get; set; }
            public int Sorting { get; set; }
            public bool HasSideBar { get; set; }
        }
    }
