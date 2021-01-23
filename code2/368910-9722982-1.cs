    using (OdbcCommand cmd = new OdbcCommand(@"UPDATE tblUsers SET FirstName = ?firstName, LastName = ?lastName, UserName = ?userName, Password = ?password, EmailId = ?email where UserId=?userId", con))
    {
        cmd.Parameters.Add("?firstName", OdbcType.VarChar, 255).Value = FirstName;
        cmd.Parameters.Add("?lastName", OdbcType.VarChar, 255).Value = LastName;
        cmd.Parameters.Add("?userName", OdbcType.VarChar, 255).Value = UserName;
        cmd.Parameters.Add("?password", OdbcType.VarChar, 255).Value = Password;
        cmd.Parameters.Add("?email", OdbcType.VarChar, 255).Value = EmailId;
        cmd.Parameters.Add("?UserId", OdbcType.Int).Value = IntUesrId;
    }
