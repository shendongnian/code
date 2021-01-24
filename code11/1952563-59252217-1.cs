    public static bool Contains(this User user, string filter)
    {
        return EF.Functions.Like(filter, $"%{user.FirstName}%") ||
            EF.Functions.Like(filter, $"%{user.LastName}%") ||
            EF.Functions.Like(filter, $"%{user.FirstName} {user.LastName}%");
    }
