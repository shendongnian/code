    var games = new[]
                        {
                            new Game() {Date = new DateTime(2010, 12, 1), TeamA = "A", TeamB="B", AtHome = "B"},
                            new Game() {Date = new DateTime(2010, 11, 1), TeamA = "A", TeamB="B", AtHome = "B"},
                            new Game() {Date = new DateTime(2010, 10, 1), TeamA = "A", TeamB="B", AtHome = "B"},
                            new Game() {Date = new DateTime(2010, 9, 1), TeamA = "A", TeamB="B", AtHome = "B"},
                            new Game() {Date = new DateTime(2010, 8, 1), TeamA = "A", TeamB="B", AtHome = "B"},
                            new Game() {Date = new DateTime(2010, 7, 1), TeamA = "A", TeamB="C", AtHome = "A"},
                            new Game() {Date = new DateTime(2010, 6, 1), TeamA = "B", TeamB="C", AtHome = "C"},
                            new Game() {Date = new DateTime(2010, 5, 1), TeamA = "B", TeamB="C", AtHome = "C"},
                            new Game() {Date = new DateTime(2010, 4, 1), TeamA = "D", TeamB="C", AtHome = "D"},
                            new Game() {Date = new DateTime(2010, 5, 1), TeamA = "B", TeamB="C", AtHome = "C"},
                            new Game() {Date = new DateTime(2010, 4, 1), TeamA = "D", TeamB="C", AtHome = "D"},
                            new Game() {Date = new DateTime(2010, 1, 1), TeamA = "A", TeamB="D", AtHome = "D"},
                            new Game() {Date = new DateTime(2009, 12, 1), TeamA = "A", TeamB="D", AtHome = "D"},
                            new Game() {Date = new DateTime(2009, 11, 1), TeamA = "A", TeamB="B", AtHome = "A"},
                            new Game() {Date = new DateTime(2009, 10, 1), TeamA = "A", TeamB="B", AtHome = "B"}
                        };
    
                var ordered = games.OrderByDescending(g => g.Date);
    
                var result = ordered.Where(
                    (g, i) =>
                    {
                        var count = ordered
                            .Skip(i + 1) // only look at previous games
                            .Where(t => (t.TeamA == g.AtHome || t.TeamB == g.AtHome)) // get all games of the same team
                            .TakeWhile(inner => inner.AtHome == g.AtHome).Count(); // see how many consecutive games have been played at home
    
                        return (count >= 3) && (count <= 5);
                    });
    
                foreach (var r in result)
                {
                    Console.WriteLine(
                        string.Format("Date {0} TeamA: {1} TeamB: {2} AtHome {3}", r.Date, r.TeamA, r.TeamB, r.AtHome)
                        );
                }
