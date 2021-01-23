    public static List<MyResult> GetMyResult(GameInfo[] gameInfos, int input)
    {
      return gameInfo.Select(gi => new MyResult()
             {
                UserId = gi.UserId, 
                ResultValue = valueExtractors[input](gi)
             }).ToList<MyResult>();
    }
