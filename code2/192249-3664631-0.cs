    string userID = "";
    try{
                userID = System.Web.HttpContext.Current.Session["userID"].ToString();
    }
    catch{
                throw new ApplicationException("UserID is null");
    }
    return userID;
