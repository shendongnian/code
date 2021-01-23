    string sessionUserId = Session["UserId"] as string;
    if(string.IsNullOrEmpty(sessionUserId))
    {
        Session["UserId"] = HttpContext.Current.User.Identity.Name.ToString();
        SqlDataReader dr = Sprocs.GetPermissionGroups();
        string groupList = "";
        while (dr.Read())
        {
            if (groupList != "")
            {
                groupList = groupList + "|" + dr["WG_Group"].ToString();
            }
            else
            {
                groupList = dr["WG_Group"].ToString();
            }
        }
        dr.Close();
        Session["UserGroups"] = groupList;
    }
