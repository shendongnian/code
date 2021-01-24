    public class Reviewer
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Address { get; set; }
    }
    public static class InitializeAutoMapper
    {
        public static void Initialize()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<JArray, Reviewer>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(so =>
                string.Join(", ", so.Select(x => new JObject(new JProperty("Name", x["Name"]))).Values("Name").ToList())))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(so =>
                string.Join(", ", so.Select(x => new JObject(new JProperty("Age", x["Age"]))).Values("Age").ToList())))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(so =>
                string.Join(", ", so.Select(x => new JObject(new JProperty("Address", x["Address"]))).Values("Address").ToList())));
            });
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            InitializeAutoMapper.Initialize();
            string json = @"[
                            { Name: ""Jason"" , Age: 20 , Address: ""London""},
                            { Name: ""Andy"" , Age: 35, Address: ""Boston""},
                            { Name: ""Mike"", Age: 27,Address: ""California""},
                            { Name: ""Maria"", Age: 22,Address: ""Arizona"" }]";
            Reviewer reviewer = AutoMapper.Mapper.Map<Reviewer>(JArray.Parse(json));
        }
    }
