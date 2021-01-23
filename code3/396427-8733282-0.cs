    protected void imgBtnActivate_onClick(object sender, EventArgs e)
    {
    int memberID;
    // Inserts Member record
    try
    {
        Database db = DatabaseFactory.CreateDatabase(ConfigManager.AppSettings["ConnectionString.Dev"]);
        DbCommand dbCommand = db.GetStoredProcCommand("dbo.ins_member_p");
        db.AddInParameter(dbCommand, "@FirstName", DbType.String, txtFirstName.Text);
        db.AddInParameter(dbCommand, "@LastName", DbType.String, txtLastName.Text);
        db.ExecuteNonQuery(dbCommand);
        memberID = Convert.ToInt32(db.GetParameterValue(dbCommand, "MemberNewID").ToString());
    }
    catch (Exception ex)
    {
        ExceptionPolicy.HandleException(ex, "Notify Policy");
    }
