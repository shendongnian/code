    var configuration = new MapperConfiguration(cfg => cfg
        .CreateMap<Model, Model>()
        .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != default)));
    var mapper = configuration.CreateMapper();
    
    var destination = new Model {Title = "Startpage", Link = "/index"};
    var source = new Model {Head = "Latest news", Link = "/news"};
    
    mapper.Map(source, destination);
    
    class Model
    {
        public string Head { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
    }
