    string sql = "UPDATE csar.UsersLog SET LoggedOffAt=@LoggedOffAt WHERE UserId=@UId AND LoggedOffAt=@Null;";
        try
        {
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@uid", USERID);
            cmd.Parameters.AddWithValue("@LoggedOffAt", DateTime.UtcNow);
            cmd.Parameters.AddWithValue("@Null", null);
            int rows = cmd.ExecuteNonQuery();
            if (rows == 1)
                return true;
            else
            {
                LastKnownError = "Failed to Insert Link";
                return false;
            }
        }
        catch (MySqlException mye)
        {
            LastKnownError = mye.Message;
            return false;
        }
