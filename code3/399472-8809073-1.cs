    internal static void AddToList(IList list, User usr)
    {
        if (!list.Cast<User>().Any(u => u.Id == user.Id))
            list.Add(usr);
    }
