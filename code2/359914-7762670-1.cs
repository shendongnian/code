    namespace BusinessLayer
    {
        public class Category
        {
            public string Name { get; set; }
            public List<Link> Links { get; set; }
    
            public static Category Load(CategoryDto dto)
            {
                var category = new Category();
                category.Name = dto.Name;
                dto.Links.ForEach(f => category.Links.Add(Link.Load(f)));
    
                return category;
            }
    
        }
    
        public class Link
        {
            public string Url { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
    
            public static Link Load(LinkDto dto)
            {
                return new Link()
                {
                    Name = dto.Name,
                    Url = dto.Url,
                    Description = dto.Description
                };
            }
        }
    }
