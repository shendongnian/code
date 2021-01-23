            List<Game> list = new List<Game>();
            list.Add(new Game() { Players = 2, Name = "Football" });
            list.Add(new Game() { Players = 1 });
            list.Add(new Game() { Players = 2, Name = "Soccer" });
            Game g = list.First<Game>(k => k.Players == 2);
            //g will contain the "Football" game
