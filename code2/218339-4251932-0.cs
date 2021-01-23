    var games = new[]
    {
        new {Date = new DateTime(2010, 12, 1), TeamA = "A", TeamB="B", AtHome = "B"},
        new {Date = new DateTime(2010, 11, 1), TeamA = "A", TeamB="B", AtHome = "A"},
        new {Date = new DateTime(2010, 10, 1), TeamA = "A", TeamB="B", AtHome = "B"},
        new {Date = new DateTime(2010, 9, 1), TeamA = "A", TeamB="B", AtHome = "A"},
        new {Date = new DateTime(2010, 8, 1), TeamA = "A", TeamB="B", AtHome = "B"},
        new {Date = new DateTime(2010, 7, 1), TeamA = "A", TeamB="B", AtHome = "B"}
    };
    var result = from g in games
                 where games.Count(c => c.AtHome == g.AtHome) > 3
                 select g;
