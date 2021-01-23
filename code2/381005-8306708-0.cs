    public static MembershipUser ToMembershipUser(this User user)
    {
        return new MembershipUser("SimplyMembershipProvider",
            user.UserName, user.UserId, user.Email, null, null, 
            user.IsApproved, user.IsLocked, user.CreateDate, 
            user.LastLoginDate, user.LastActivityDate, user.CreateDate,
            DateTime.MinValue);
    }
