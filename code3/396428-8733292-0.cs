    protected void imgBtnActivate_onClick(object sender, EventArgs e)
    {
        // define it here
        int memberID = -1:
        // Inserts Member record
        try
        {
            ......
            db.ExecuteNonQuery(dbCommand);
            memberID = Convert.ToInt32(db.GetParameterValue(dbCommand, "MemberNewID").ToString());
        }
        catch (Exception ex)
        {
            ExceptionPolicy.HandleException(ex, "Notify Policy");
        }
    
        // Insert Member Email
        try
        {
            ......
            // then it'll be visible and useable here!
            db.AddInParameter(dbCommand, "MemberID", DbType.Int32, memberID);
            .....
        }
        catch (Exception ex)
        {
            ExceptionPolicy.HandleException(ex, "Notify Policy");
        }
    }
