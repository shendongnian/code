    private void Calculate(Player player)
    {
        for (int i = 0; i < player.Game.Stages.Length; i++)
        {
            int firstThrow = player.Game.Stages[i].FirstTry;
            int secondThrow = player.Game.Stages[i].SecondTry;
            int sumFirstAndSecond = firstThrow + secondThrow;
            if ((sumFirstAndSecond == 10) && (firstThrow != 10) && i != player.Game.Stages.Length- 1)
            {
                int stageScore= player.Game.Stages[i].TotalScore + player.Game.Stages[i + 1].FirstTry;
                player.Game.Stages[i].TotalScore = sumFirstAndSecond + stageScore;
             }
             else if (i > 0) player.Game.Stages[i].TotalScore = player.Game.Stages[i - 1].TotalScore + sumFirstAndSecond;
        }
    }
