    string localDatabasePath = @"FOLDER";
    string localDatabaseName = "FILE.sdf";
    string localDatabasePass = "WhyDoYouCare";
    string localDatabaseUsersTable = "userstable";
    
                    SqlCeConnection localDatabaseConn = new SqlCeConnection("Data Source = " + localDatabasePath + "\\" + localDatabaseName + "; Password=" + localDatabasePass);
                    localDatabaseConn.Open();
                    SqlCeCommand localDatabaseCmd = localDatabaseConn.CreateCommand();
                    localDatabaseCmd.CommandText = "SELECT something FROM " + localDatabaseUsersTable + " WHERE username='" + Username + "'";
                    localDatabaseCmd.ExecuteNonQuery();
                    SqlCeDataReader localDatabaseRdr = localDatabaseCmd.ExecuteReader();
                
