    class Program
    {
        static void Main(string[] args)
        {
            AutoMapper.Mapper.CreateMap<Source, Dest>()
                .ForMember(
                    dest => dest.Prop1,
                    src => src.MapFrom(m => float.Parse(m.Prop1, System.Globalization.CultureInfo.InvariantCulture)
                ));
            Source sourceObject = new Source() { Prop1 = "1.5" };
            Dest destination = AutoMapper.Mapper.Map<Source, Dest>(sourceObject);
            Console.WriteLine("value {0}", destination.Prop1);
        }
    }
    
    public class Source
    {
        public string Prop1 { get; set; }
    }
    
    public class Dest
    {
        public float Prop1 { get; set; }
    }
