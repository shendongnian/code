    <asp:DropDownList ID="uxListUsers" runat="server">
    ListItemCollection myListUsersInRoles = new ListItemCollection();
            foreach (aspnet_Users myUser in context.aspnet_Users)
            {
                // Use of navigation Property EntitySet
                if (myUser.aspnet_Roles.Any(r => r.RoleName == "CMS-AUTHOR" || r.RoleName == "CMS-EDITOR"))
                    myListUsersInRoles.Add(new ListItem(myUser.UserName.ToString(), myUser.UserId.ToString()));
            }
            uxListUsers.DataSource = myListUsersInRoles; // MAYBE PROBLEM HERE????
            uxListUsers.DataBind();
