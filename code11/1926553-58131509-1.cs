	public static class Cache
	{
		private static List<UserCall> userCalls = new List<UserCall>();    
		private static void AddCall(long userID, long callID)
		{
			lock(userCalls)
			{
				userCalls.Add(
						new UserCall
						{
							CallID = callID,
							UserID = userID
						});
			}
		}
		public static UserCall GetCall(long userID)
		{
			UserCall userCall = null;
			lock(userCalls)
				userCall = UserCalls.FirstOrDefault(x => x.UserID == userID);
			return userCall;
		}
		public static void RemoveCall(long userID)
		{
			lock(userCalls)
				userCalls.RemoveAll(x => x.UserID == userID);
		}
	}
