    /// <summary>
    /// Gets information from the data source for a user.
    /// Provides an option to update the last-activity date/time stamp for the user.
    /// </summary>
    /// <param name="username">The name of the user to get information for.</param>
    /// <param name="userIsOnline">true to update the last-activity date/time 
    /// stamp for the user; false to return user information without updating 
    /// the last-activity date/time stamp for the user.</param>
    /// <returns>A MembershipUser object populated with the specified
    /// user's information from the data source.</returns>
    public override MembershipUser GetUser(string username, bool userIsOnline)
    {
        // Get User from my custom database
        User user = Database.User.GetUser(username);
        // Convert User to MebmershipUser (or return null if User == null)
        return user == null ? null : new MembershipUser(
            "CustomMembershipProvider",
            user.UserName, 
            user.UserID,
            user.Email,
            string.Empty, 
            user.Comments, 
            user.Active,
            false, 
            user.CreatedDate, 
            user.LastLoginDate, 
            DateTime.Now, 
            user.LastPasswordChangedDate, 
            DateTime.Now);
    }
