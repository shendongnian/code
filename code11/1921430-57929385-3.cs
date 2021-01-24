    if (!UserIsInRole("Owners"))
    {
        RegisterControlRule("CreatorID", AccessPermission.Allow, UserId);
    }
    RegisterControlRule("delegeatedToId", AccessPermission.Allow, UserId);
