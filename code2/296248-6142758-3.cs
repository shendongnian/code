		private Expression<Func<Message, bool>> UserSelector(string username, bool sent)
		{
			Func<Message, bool> innerFunc = message =>
			{
			    if (sent)
			    {
			        return string.Equals(message.FromUser.Username, username, StringComparison.InvariantCultureIgnoreCase) &&
			                !message.SenderDeleted;
			    }
			    return string.Equals(message.ToUser.Username, username, StringComparison.InvariantCultureIgnoreCase) &&
			            !message.RecipientDeleted;
			};
			return message => innerFunc(message);
		}
