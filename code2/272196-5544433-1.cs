    void DetailsView1_ItemCommand(Object sender, DetailsViewCommandEventArgs e){
        if (e.CommandName == "SetToRenter")
        {
            // if UserID is in second row:
            DetailsViewRow row = DetailsView1.Rows[1];
    
            // Get the Username from the appropriate cell.
            // In this example, the Username is in the second cell  
            String UserID = row.Cells[1].Text;
            MembershipUser memUser = Membership.GetUser(UserId);
            Roles.AddUserToRole(memUser.UserName, "Renter");
        }
    }
