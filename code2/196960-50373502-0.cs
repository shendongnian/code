    public static DateTime GetPasswordExpirationDate(UserPrincipal user)
    {
        DirectoryEntry deUser = (DirectoryEntry)user.GetUnderlyingObject();
        ActiveDs.IADsUser nativeDeUser = (ActiveDs.IADsUser)deUser.NativeObject;
        return nativeDeUser.PasswordExpirationDate;
    }
