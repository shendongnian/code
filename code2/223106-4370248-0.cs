        ConclusionPage.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CurrentUser", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "UserID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
        ConclusionPage.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ItemID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ItemID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
        ConclusionPage.CommandType = System.Data.CommandType.Text;
        ConclusionPage.UpdateCommand = "UPDATE tblUserItems SET Quantity = Quantity+1 WHERE (UserID = @CurrentUser) AND (ItemID = '@ItemID')";
        foreach (UserItem ItemID in (List<UserItem>)Session["UserSession"])
        {
            ConclusionPage.Parameters[0].Value = CurrentUser;
            ConclusionPage.Parameters[1].Value = ItemID;
            ConclusionPage.ExecuteNonQuery();
        }
