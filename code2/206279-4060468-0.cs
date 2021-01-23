    void Restore(string ConnectionString, string DatabaseFullPath, string backUpPath)
    {
        using (SqlConnection con = new SqlConnection(ConnectionString))
        {
            con.Open();
    
            string UseMaster = "USE master";
            SqlCommand UseMasterCommand = new SqlCommand(UseMaster, con);
            UseMasterCommand.ExecuteNonQuery();
    
            string Alter1 = @"ALTER DATABASE [" + DatabaseFullPath + "] SET Single_User WITH Rollback Immediate";
            SqlCommand Alter1Cmd = new SqlCommand(Alter1, con);
            Alter1Cmd.ExecuteNonQuery();
    
            string Restore = @"RESTORE DATABASE [" + DatabaseFullPath + "] FROM DISK = N'" + backUpPath + @"' WITH  FILE = 1,  NOUNLOAD,  STATS = 10";
            SqlCommand RestoreCmd = new SqlCommand(Restore, con);
            RestoreCmd.ExecuteNonQuery();
    
            string Alter2 = @"ALTER DATABASE [" + DatabaseFullPath + "] SET Multi_User";
            SqlCommand Alter2Cmd = new SqlCommand(Alter2, con);
            Alter2Cmd.ExecuteNonQuery();
    
            labelReport.Text = "Successful";
        }
    }
