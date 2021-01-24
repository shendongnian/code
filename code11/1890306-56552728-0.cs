    public class One 
    {
      public int A {get; set;}
      public int B {get; set;}
      public int C {get; set;}
    }
    public class Two
    {
      public int Sum {get; set;} //sum = a + b +c ;
    }
    cfg.CreateMap<One, Two>()
      .ForMember(dest => dest.Sum, m => m.MapFrom(src => src.A + src.B + src.C));
