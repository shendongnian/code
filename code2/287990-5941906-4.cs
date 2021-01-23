    List<Sample> sample = new List<Sample>
            {
                new Sample { Id = 1, Time = DateTime.Now },
                new Sample { Id = 1, Time = DateTime.Now.AddDays(1) },
                new Sample { Id = 2, Time = DateTime.Now.AddDays(2) },
                new Sample { Id = 2, Time = DateTime.Now.AddDays(3) },
                new Sample { Id = 3, Time = DateTime.Now.AddDays(4) },
            };
    foreach (var group in sample.GroupBy(x => x.Id))
    {
        foreach (var element in group)
        {
            Console.WriteLine(element.Id);
            Console.WriteLine(element.Time);
        }
    }
