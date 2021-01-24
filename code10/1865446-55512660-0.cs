    var ldetails = _context.RegistrationUsers.Select(x=>new RegistrationUser
	{
	  PMId=x.PMId,
	  UserName=x.UserName,
	  Password=x.Password,
	  Token=x.Token,
	  ListFriends=x.ListFriends.Select(q => new ListFriend
		{
		  UserId=q.UserId,
		  UserFriendName,q.UserFriendName,
		  MessagesDetails=q.Where(a => a.TextMessage == messagesDetail.TextMessage).ToList()
		}).ToList()				 
	}).SingleOrDefault(c => c.UserName == Context.User.Identity.Name);
