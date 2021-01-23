    var games = new[]
    {
        new Game() {Date = new DateTime(2010, 12, 1), TeamA = "A", TeamB="B", AtHome = "B"},
        new Game() {Date = new DateTime(2010, 11, 1), TeamA = "A", TeamB="B", AtHome = "A"},
        new Game() {Date = new DateTime(2010, 10, 1), TeamA = "A", TeamB="B", AtHome = "B"},
        new Game() {Date = new DateTime(2010, 9, 1), TeamA = "A", TeamB="B", AtHome = "A"},
        new Game() {Date = new DateTime(2010, 8, 1), TeamA = "A", TeamB="B", AtHome = "B"},
        new Game() {Date = new DateTime(2010, 7, 1), TeamA = "A", TeamB="C", AtHome = "A"},
        new Game() {Date = new DateTime(2010, 6, 1), TeamA = "B", TeamB="C", AtHome = "C"},
        new Game() {Date = new DateTime(2010, 5, 1), TeamA = "B", TeamB="C", AtHome = "C"},
        new Game() {Date = new DateTime(2010, 4, 1), TeamA = "D", TeamB="C", AtHome = "C"},
        new Game() {Date = new DateTime(2010, 3, 1), TeamA = "D", TeamB="B", AtHome = "D"},
        new Game() {Date = new DateTime(2010, 2, 1), TeamA = "D", TeamB="B", AtHome = "B"},
        new Game() {Date = new DateTime(2010, 1, 1), TeamA = "A", TeamB="D", AtHome = "D"},
        new Game() {Date = new DateTime(2009, 12, 1), TeamA = "A", TeamB="D", AtHome = "A"},
        new Game() {Date = new DateTime(2009, 11, 1), TeamA = "A", TeamB="B", AtHome = "A"},
        new Game() {Date = new DateTime(2009, 10, 1), TeamA = "A", TeamB="B", AtHome = "B"}
    };
    var result = from g in games
                 orderby g.Date descending
                 where games.Where(w => (w.TeamA == g.AtHome || w.TeamB == g.AtHome) 
                                        && w.Date <= g.Date)
                            .Take(5)
                            .Count(c => c.AtHome == g.AtHome) >= 3
                 select g;
	
    class Game
    {
        public DateTime Date { get; set; }
        public string TeamA { get; set; }
        public string TeamB { get; set; }
        public string AtHome { get; set; }
    }
