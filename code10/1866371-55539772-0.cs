    #region Save Data To Database
	using (MyDatabaseEntities1 dc = new MyDatabaseEntities1())
	{
		var maxUserId = dc.Users.Max(x=>x.UserId);
		if(maxUserId !=null)
			user.UserId = maxUserId + 1;
		
		dc.Users.Add(user);
		dc.SaveChanges();
		//Send Email To User
		SendVerificationLinkEmail(user.EmailID, user.ActivationCode.ToString());
		message = "Registration Success!" + " " + "Account activation link" + "has been sent to your email id:" + user.EmailID;
		Status = true;
	}
    #endregion
