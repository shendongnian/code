            string[] array = new string[] { "A", "2A", "3A", "4A", "5A", "6A", "7A", "8A", "9A", "10A" };
            var results = array.AsParallel().Select((item, i) =>
            new
            {
                Index = i,
                Result = ProcessItem(item)
            })
            .OrderBy(x => x.Index)
            .Select(i=>i.Result)
            .ToList();
