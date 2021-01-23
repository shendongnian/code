    var now = DateTime.Now;
    var movements = new []
    {
        new Movement { areaId = 1, startTime = now.AddDays(-10), endTime = now.AddDays(-9) },
        new Movement { areaId = 2, startTime = now.AddDays(-8), endTime = now.AddDays(-7) },
        new Movement { areaId = 3, startTime = now.AddDays(-5), endTime = now.AddDays(-2) },
        new Movement { areaId = 4, startTime = now.AddDays(-2), endTime = now.AddDays(0) }
    };
    var longest = movements.Aggregate((m1, m2) =>
        m1.endTime.Subtract(m1.startTime) > m2.endTime.Subtract(m2.startTime) ? m1 : m2
    );
