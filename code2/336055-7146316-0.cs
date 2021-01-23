            var lines = new[]
                            {
                                "R80\t123456\tsomething here1",
                                "R81\t123456\tsomething here1",
                                "R81\t123456\tsomething here1",
                            };
            var items = lines.Select(i => i.Split('\t')).Select(i => new {Name = i[0], PartNumber = i[1], Description = i[2]});
            var outLines =
                items.GroupBy(i => i.Name).Select(
                    i =>
                    string.Format("{0}\t{1}\t{2}\t{3}", i.First().Name, i.First().PartNumber, i.First().Description,
                                  i.Count()));
