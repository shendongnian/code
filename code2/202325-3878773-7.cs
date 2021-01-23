    private int winningSharkTotal(int Winner)
    {
    int Result = 0;
    for (int i = 0; i<3; i++)
    {
        Result += bets[i+(Winner*3)];
    }
        return Result;
    }
