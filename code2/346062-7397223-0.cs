	public static class GameInfoEx
	{
		public static IEnumerable<MyResult> ToMyResults(
			this IEnumerable<GameInfo> gameInfos,
			Func<GameInfo, object> selector)
		{
			return gameInfos.Select(gi => gi.ToMyResult(selector));
		}
		
		public static MyResult ToMyResult(
			this GameInfo gameInfo,
			Func<GameInfo, object> selector)
		{
			return new MyResult()
			{
				UserId = gameInfo.UserId,
				ResultValue = selector(gameInfo).ToString()
			};
		}
	}
