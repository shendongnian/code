        class Fixture
        {
            public string Home { get; set; }
            public string Away { get; set; }
        }
        List<Fixture> CalculateFixtures()
        {
            string[] players = new string[] { "A", "B", "C", "D" };
            List<Fixture> fixtures = new List<Fixture>();
            for (int i = 0; i < players.Length; i++)
            {
                for (int j = 0; j < players.Length; j++)
                {
                    if (players[i] != players[j])
                    {
                        fixtures.Add(new Fixture() { Home = players[i], Away = players[j] });
                    }
                }
            }
            fixtures.Reverse();
            List<Fixture> sortedFixtures = new List<Fixture>();
            int gameweeks = (players.Length - 1) * 2;
            int gamesPerWeek = gameweeks / 2;
            for (int i = 0; i < gameweeks; i++)
            {
                sortedFixtures.AddRange(TakeUnique(fixtures, gamesPerWeek));
            }
            return sortedFixtures;
        }
        List<Fixture> TakeUnique(List<Fixture> fixtures, int gamesPerWeek)
        {
            List<Fixture> result = new List<Fixture>();
            for (int i = 0; i < gamesPerWeek; i++)
            {
                for (int j = fixtures.Count - 1; j >= 0; j--)
                {
                    if (!result.Any(r => r.Home == fixtures[j].Home || r.Away == fixtures[j].Home || r.Home == fixtures[j].Away || r.Away == fixtures[j].Away))
                    {
                        //teams not yet used
                        result.Add(fixtures[j]);
                        fixtures.RemoveAt(j);
                    }
                }
            }
            return result;
        }
