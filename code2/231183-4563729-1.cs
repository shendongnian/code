      class Category
      {
        public int CategoryId { get; set; }
        public List<Template> Templates
        {
          get
          {
            return Repository.Templates.Where(t => t.CategoryId == this.CategoryId).ToList();
          }
        }
      }
