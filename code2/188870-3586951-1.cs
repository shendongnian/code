        IList<IUser> users;
        using (AbleridgeDataContext context = new AbleridgeDataContext())
        {
            users = (from u in context.Users select u).Cast<IUser>().ToList();
        }
