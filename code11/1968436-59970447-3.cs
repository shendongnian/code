    public static Choice GetAdvantageByChoice(this Choice choice) =>
      choice switch
      {
          Choice.Paper => Choice.Rock,
          Choice.Rock => Choice.Scissors,
          Choice.Scissors => Choice.Paper,
          _ => throw new ArgumentException()
      };
