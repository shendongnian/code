    public static class Program
    {
        public static void Main()
        {
            var config = new MapperConfiguration(conf => conf.CreateMap<Source, Target>().PreserveReferences());
            var mapper = config.CreateMapper();
            var source = new Source();
            var list = new[] { source, source, source };
            var firstRun = mapper.Map<IEnumerable<Target>>(list);
            var secondRun = mapper.Map<IEnumerable<Target>>(list);
            // Returns two items
            var diffs = firstRun.Concat(secondRun).Distinct();
            foreach (var item in diffs)
            {
                Console.WriteLine(item.Id);
            }
        }
    }
    public class Source
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
    public class Target
    {
        public string Id { get; set; }
    }
