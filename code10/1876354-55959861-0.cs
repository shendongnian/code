    var now = DateTime.Now;
    var nums = new List<Num>
    {
        new Num { Min = now, Max = now.AddDays(1) },
        new Num { Min = now.AddDays(10), Max = now.AddDays(50) },
        new Num { Min = now.AddDays(51), Max = now.AddDays(100) },
    };
    var minMaxNum = nums.Select(num => new Num
    {
        Min = nums.Min(_ => _.Min),
        Max = nums.Max(_ => _.Max),
    }).First();
