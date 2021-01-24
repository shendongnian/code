    [TestMethod]
    public void TestCase2_FromComments()
    {
        var projects = new List<Project>() {
			  new Project { Name = "A", Begin = new DateTime(2019, 4, 2), End = new DateTime(2019, 8, 17) }
			, new Project { Name = "B", Begin = new DateTime(2019, 6, 1), End = new DateTime(2019, 7, 1) }
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
    }
