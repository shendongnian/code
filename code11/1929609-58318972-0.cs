        private void OPCode(string sName,string sMiddleName,string sSurname,DateTime sBirthdate,string sSex,string sNationality,DateTime sDateOfArrival,int sCardID,string sUsername,string sPassword,string sPhoneNumber, int tb_cardID)
        {
            using (SqlConnection cnn = new SqlConnection(Globals.sqlConnect))
            {
                using (SqlCommand command = new SqlCommand("INSERT INTO dbo.Refugee ([Name],[Middlename],[Surname],[Birthdate],[Sex],[Nationality],[Date_of_arrival],[ID_Card_Number],[Username],[Password],[Phone_Number]) VALUES (@sName, @sMiddleName, @sSurname, @sBirthdate, @sSex, @sNationality, @sDateOfArrival, @sCardID, @sUsername, @sPassword, @sPhoneNumber);", cnn))
                {
                    command.Parameters.Add("@sName", SqlDbType.VarChar).Value = sName;
                    command.Parameters.Add("@sMiddleName", SqlDbType.VarChar).Value = sMiddleName;
                    command.Parameters.Add("@sSurname", SqlDbType.VarChar).Value = sSurname;
                    command.Parameters.Add("@sBirthdate", SqlDbType.DateTime).Value = sBirthdate;
                    command.Parameters.Add("@sSex", SqlDbType.VarChar).Value = sSex;
                    command.Parameters.Add("@sNationality", SqlDbType.VarChar).Value = sNationality;
                    command.Parameters.Add("@sDateOfArrival", SqlDbType.DateTime).Value = sDateOfArrival;
                    command.Parameters.Add("@sCardID", SqlDbType.Int).Value = sCardID;
                    command.Parameters.Add("@sUsername", SqlDbType.VarChar).Value = sUsername;
                    command.Parameters.Add("@sPassword", SqlDbType.VarChar).Value = sPassword;
                    command.Parameters.Add("@sPhoneNumber", SqlDbType.VarChar).Value = sPhoneNumber;
                    cnn.Open();
                    command.ExecuteNonQuery();
                } //disposes command
                if (Properties.Settings.Default.HoF == true)
                {
                    using(SqlCommand command = new SqlCommand("INSERT INTO dbo.Family ([Family_name],[Head_Of_Family_ID_Card_Number]) VALUES (@FamilyName, @tb_carID;", cnn))
                    { 
                        command.Parameters.Add("@Familyname", SqlDbType.VarChar).Value = Properties.Settings.Default.Familyname;
                        command.Parameters.Add("@tb_cardID", SqlDbType.Int).Value = tb_cardID; 
                        command.ExecuteNonQuery();
                    }//disposes second command
                }
            }//closes and disposes connection
        }
