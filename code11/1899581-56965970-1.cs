    public class Project
    {
        public string Name { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
    }
    [TestMethod]
    public void TestMethod1()
    {
        var projects = new List<Project>() {
              new Project { Name = "A", Begin = new DateTime(2000, 1, 1), End = new DateTime(2000, 12, 31) }
            , new Project { Name = "B", Begin = new DateTime(2001, 1, 1), End = new DateTime(2001, 12, 31) }
            , new Project { Name = "C", Begin = new DateTime(2010, 1, 1), End = new DateTime(2010, 12, 31) }
            , new Project { Name = "D", Begin = new DateTime(2010, 6, 1), End = new DateTime(2010, 7, 1) }
         };
        var grouped = projects.JoinBy(
            x => x.Begin,
            x => (begin: x.Begin, end: x.End),
            (x1, x2) => x2.begin <= x1.end.AddDays(1) && x1.begin <= x2.end.AddDays(1));
        var builder = new StringBuilder();
        foreach (var grp in grouped)
        {
            builder.AppendLine(string.Join(", ", grp.Select(x => x.Name)));
        }
        var rendered = builder.ToString();
        // rendered =>
        // A, B
        // C, D
    }
