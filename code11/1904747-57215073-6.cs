    public ActionResult Match()
    {
        ...
        var match = new MVCApp.Models.Match
        {
            AdversaryTeam = "Equipe de France",
            Field = "Stade de France",
            MatchDay = DateTime.Today,
            MatchTime = DateTime.Now,
            TeamOne = new Team
            {
                Players = new List<Player>
                {
                    new Player { PlayerID = 1, Firstname = "Zineeddine", Lastname = "Zidane", Poste = "" },
                    new Player { PlayerID = 2, Firstname = "Roberto", Lastname = "Carlos", Poste = "" },
                    new Player { PlayerID = 3, Firstname = "Gianluca", Lastname = "Pagliuca", Poste = "" },
                }
            },
             TeamTwo = new Team
             {
                Players = new List<Player>
                {
                    new Player { PlayerID = 1, Firstname = "Zineeddine", Lastname = "Zidane", Poste = "" },
                    new Player { PlayerID = 2, Firstname = "Roberto", Lastname = "Carlos", Poste = "" },
                    new Player { PlayerID = 3, Firstname = "Gianluca", Lastname = "Pagliuca", Poste = "" },
                }
             }
        };
        var vm = new MatchPlayersVM
        {
            Match = match, 
            TeamOnePlayers = match.TeamOne.Players.Select(p => new SelectListItem { Text = p.Firstname, Value = p.PlayerID.ToString() }),
            TeamTwoPlayers = match.TeamTwo.Players.Select(p => new SelectListItem { Text = p.Firstname, Value = p.PlayerID.ToString() }),
        };
        ViewBag.MatchVM = vm;
        return View();
    }
