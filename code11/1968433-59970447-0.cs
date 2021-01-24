    public enum Choice
    {
      Rock,
      Paper,
      Scissors
    }
    
    public static class ChoiceExt
    {
        public static Choice GetAdvantageByChoice(this Choice choice)
        {
            switch (choice)
            {
                case Choice.Rock:
                    return Choice.Scissors;
                case Choice.Paper:
                    return Choice.Rock;
                case Choice.Scissors:
                    return Choice.Paper;
            }
        }
    }
