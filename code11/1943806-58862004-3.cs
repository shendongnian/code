    List<Block> blocks = new List<Block>();
    //If either of your lists is empty, this avoids an IndexOutOfRange exception
    if (dailyRoutine.B.Count > 0 && dailyRoutine.G.Count > 0)
    {
        //Also need to check the index isn't going to be greater than the count of G
        for (int i = 0, j = dailyRoutine.B[0] > dailyRoutine.G[0] ? 1 : 0; i < dailyRoutine.B.Count && j < dailyRoutine.G.Count; i++, j++)
        {
            blocks.Add(new Block()
            {
                Start = dailyRoutine.B[i],
                End = dailyRoutine.G[j] //note this is 'j' not 'i'
            });
        }
    }
