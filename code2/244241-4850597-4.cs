    namespace WebProject.ViewModels
    {
        public class News
        {
            public int Id { get; set; } // not used when creating new entries but used with editing/deleting hens not being required
        
            [Required]
            public string Text { get; set; }
        
            [Required]
            public HttpPostedFileBase Image { get; set; }
            public Data.News ToData()
            {
                return new Data.News {
                    Id = this.Id,
                    Text = this.Text,
                    NewsImage = new Data.NewsImage {
                        Id = this.Id,
                        Image = // convert to byte[]
                    }
                }
            }
        }
    }
