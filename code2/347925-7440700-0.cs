	public class UserInfo
	{
		private int userID;
		public int UserID
		{
			get { return userID; }
		}
		private string userName;
		public string UserName
		{
			get { return userName; }
		}
		public UserInfo(int userID, string userName)
		{
			this.userID = userID;
			this.userName = userName;
		}
	}
	public static class GlobalInfo
	{
		private static UserInfo currentUser;
		public static UserInfo CurrentUser
		{
			get { return currentUser; }
			set { currentUser = value; }
		}
	}
