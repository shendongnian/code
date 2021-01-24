    public async void ChangeStatus(int userId, string column, int status)
    {
        var member = Users.Members[Users.Members.FindIndex(c => c.Id == userId)];
        var settings = member.SellerSettings;
        var propInfo = settings.GetType().GetProperty(column);
        if (propInfo != null)
        {
            propInfo.SetValue(settings, Convert.ToBoolean(status), null);
        }
    }
