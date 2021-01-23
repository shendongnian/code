		private Expression<Func<Message, bool>> UserSelector(string username, bool sent)
		{
			return message=> InnerFunc(message, username, sent);
		}
		private static bool InnerFunc(Message message, string username, bool sent)
		{
			if(sent)
			{
				return string.Equals(message.FromUser.Username, username, StringComparison.InvariantCultureIgnoreCase) && !message.SenderDeleted;
			}
			return string.Equals(message.ToUser.Username, username, StringComparison.InvariantCultureIgnoreCase) && !message.RecipientDeleted;
		}
