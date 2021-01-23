      class Template
      {
        public int CategoryId { get; set; }
        public int TemplateId { get; set; }
        public List<Instance> Instances
        {
          get
          {
            return Repository.Instances.Where(i => i.TemplateId == this.TemplateId).ToList();
          }
        }
      }
