    public Form1()
    {
        ....
        Tournament tournament = new Tournament();
        tournament.PlayerList.Add(new Player("Hero", 5000));
        tournament.PlayerList.Add(new Player("Villain1", 3000));
        tournament.PlayerList.Add(new Player("Villain2", 4000));
        int chips = tournament.PlayerList[0].StackPercentage.ToString();
    }
