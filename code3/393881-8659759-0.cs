    string sql = string.Format("CREATE PROCEDURE [{0}]..[spInsertADAuthorization] @AD_Account varchar(255),@AD_SID varchar(255),@AD_EmailAddress varchar(255),@DateImported datetime,@Active bit AS BEGIN SET NOCOUNT ON; INSERT INTO AD_Authorization (AD_Account, AD_SID, AD_EmailAddress, DateImported, Active) VALUES (@AD_Account,@AD_SID,@AD_EmailAddress,@DateImported,@Active)", txtDBName.Text);
    using (SqlConnection connection = new SqlConnection(ConnectionString))
    {
        using (SqlCommand cmd = new SqlCommand(sql, connection))
        {
            connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
