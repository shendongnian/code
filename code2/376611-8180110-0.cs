    protected void rgUser_DeleteCommand(object source, GridCommandEventArgs e)
    {
        GridDataItem gdiItem = (GridDataItem)e.Item;
        try
        {
            string strUserKey = gdiItem.GetDataKeyValue("ProviderUserKey").ToString();
            Guid guiUserKey = new Guid(strUserKey);
            string strUserName = Membership.GetUser(guiUserKey).UserName.ToString();
            Membership.DeleteUser(strUserName);
        }
        catch (Exception ex)
        {
            //handle exception
        }
    }
