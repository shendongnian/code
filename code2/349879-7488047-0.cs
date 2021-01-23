    var result = methodList
        .Select(
            x =>
            {
                var items = x.Split(';');
                return new { Name = items[0], Value = Int32.Parse(items[1]) };
            })
        .GroupBy(pair => pair.Name)
        .Select(
            grouping =>
            {
                var sum = grouping.Sum(x => x.Value);
                return String.Format("{0} {1}", grouping.Key, sum);
            });
