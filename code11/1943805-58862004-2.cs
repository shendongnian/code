    List<Block> blocks = new List<Block>();
    //Also need to check the index isn't going to be greater than the count of G
    for (int i = 0; i < dailyRoutine.B.Count && i + 1 < dailyRoutine.G.Count; i++)
    {
        blocks.Add(new Block()
        {
            Start = dailyRoutine.B[i],
            End = dailyRoutine.G[i + 1] //i + 1 will be the second instance when i is the first
        });
    }
