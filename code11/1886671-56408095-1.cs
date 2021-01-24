    public Expression<Func<TEntity, bool>> GetUserPredicate<TEntity>(int userID)
        where TEntity : IUserProvider
    {
        return e => e.UserID == userID;
    }
