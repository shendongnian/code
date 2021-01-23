    public static UserActivations GetUserActivationsByUser(User user = null, Guid userId = new Guid())
    {
        Contract.Ensures(Contract.Result<UserActivations>() != null);
        Guid id = new Guid();
        if (user != null)
            id = user.Id;
        else
            if (userId != Guid.Empty)
                id = userId;
            else
                throw new Exception("Either user or userId must have a value");
        UserActivations uas = new UserActivations(StorageManager.SelectAll(
            Criteria.And(
            Criteria.EqualTo("UserId", id),
            Criteria.EqualTo("Deleted", false))));
        return uas;
    }
