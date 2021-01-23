    internal class Program
    {
        private static void Main(string[] args)
        {
            SourceSiblings[] brothers = {
                                            new SourceSiblings {Name = "A", Relation = 1},
                                            new SourceSiblings {Name = "B", Relation = 2}
                                        };
            var dest = new DestinationOuter();
            Mapper.CreateMap<SourceSiblings, DestinationInner>();
            Mapper.CreateMap<IEnumerable<SourceSiblings>, DestinationOuter>()
                .ForMember(d => d.Name, opt => opt.Ignore())
                .ForMember(d => d.Age, opt => opt.Ignore())
                .ForMember(d => d.Siblings, opt => opt.MapFrom(s => s));
            Mapper.Map(brothers, dest);
            Console.Write(dest.Siblings.Count);
            Console.ReadLine();
        }
    }
    public class DestinationOuter
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<DestinationInner> Siblings { get; set; }
    }
    public class DestinationInner
    {
        public string Name { get; set; }
        public int Relation { get; set; }
    }
    public class SourceSiblings
    {
        public string Name { get; set; }
        public int Relation { get; set; }
    }
