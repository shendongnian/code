    object userID = System.Web.HttpContext.Current.Session["userID"];
    if (userID == null)
    {
        throw new ApplicationException("UserID is null");
    }
    return userID.ToString();
