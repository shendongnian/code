    user = Membership.GetUser(new Guid(item["UserID"].ToString()));
    if (user == null)
    {
            // anonymous profile
            profil = (ProfileCommon)ProfileBase.Create(item["UserID"].ToString());
    }
    else
    {
            // hey! I know you!
            profil = (ProfileCommon)ProfileBase.Create(user.UserName);
    }
