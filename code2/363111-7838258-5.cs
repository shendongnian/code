        class Fixture
        {
            public string Home { get; set; }
            public string Away { get; set; }
        }
        void CallCode()
        {
            string players = new string[] { "A", "B", "C", "D" };
            List<Fixture> fixtures = CalculateFixtures(players);
        }
        List<Fixture> CalculateFixtures(string[] players)
        {
            //create a list of all possible fixtures (order not important)
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
            fixtures.Reverse();//reverse the fixture list as we are going to remove element from this and will therefore have to start at the end
            //calculate the number of game weeks and the number of games per week
            int gameweeks = (players.Length - 1) * 2;
            int gamesPerWeek = gameweeks / 2;
            List<Fixture> sortedFixtures = new List<Fixture>();
            //foreach game week get all available fixture for that week and add to sorted list
            for (int i = 0; i < gameweeks; i++)
            {
                sortedFixtures.AddRange(TakeUnique(fixtures, gamesPerWeek));
            }
            return sortedFixtures;
        }
        List<Fixture> TakeUnique(List<Fixture> fixtures, int gamesPerWeek)
        {
            List<Fixture> result = new List<Fixture>();
            //pull enough fixture to cater for the number of game to play
            for (int i = 0; i < gamesPerWeek; i++)
            {
                //loop all fixture to find an unused set of teams
                for (int j = fixtures.Count - 1; j >= 0; j--)
                {
                    //check to see if any teams in current fixtue have already been used this game week and ignore if they have
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
