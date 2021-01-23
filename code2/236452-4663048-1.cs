    public class Foo {
        public DateTime bar { get; set; }
    }
    
    public class Foo1
    {
        public DateTime bar1 { get; set; }
    }
    Mapper.CreateMap<Foo, Foo1>()
        .ForMember(x => x.bar1, opt => opt.MapFrom(x => DateTime.Now)); // not using x, your function returns the value for bar1
