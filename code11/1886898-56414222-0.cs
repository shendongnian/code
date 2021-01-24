        Dictionary<string, Player> myDic = new Dictionary<string, Player>();
        Player p1 = new Player() { GameID = 1, Index = "a" };
        Player p2 = new Player() { GameID = 2, Index = "b" };
        Player p3 = new Player() { GameID = 1, Index = "c" };
        Player p4 = new Player() { GameID = 3, Index = "d" };
        myDic.Add(p1.Index, p1);
        myDic.Add(p2.Index, p2);
        myDic.Add(p3.Index, p3);
        myDic.Add(p4.Index, p4);
