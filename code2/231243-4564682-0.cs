    List<double> sizes = new List<double>() {
        1.1, 2.3, 4.4, 1.8, 4.2, 0.7, 3.8, 1.2, 4.0, 3.2
    };
    var answer = sizes.Aggregate(
        new List<List<double>>(),
        (groups, d) => {
            var group = groups.FirstOrDefault(g => g.Sum() + d < 5);
            if (group == null) {
                group = new List<double>();
                groups.Add(group);
            }
            group.Add(d);
            return groups;
         }
    );
