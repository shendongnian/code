    public UserCredentialMap()
    {
        Id(x => x.Id, "UserId");
        References(x => x.User, "UserId")
                .Not.Update()
                .Not.Insert();
    }
