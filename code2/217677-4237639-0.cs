    var zero = EnumerableEx.Return(new MyObject { Value = 0 });
    var result = list
        .GroupBy(o => new { o.City, o.ID })
        .SelectMany(g => g
            .Zip(zero.Concat(g), (o1, o2) =>
            new { O = o1, Diff = o1.Value - o2.Value }));
