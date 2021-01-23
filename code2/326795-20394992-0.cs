        string strmessage;
        int intResult;
       
        public string login(string username, string password)// login method
        {
            dataBaseObj.sqlconn.Open();
            dataBaseObj.sqlCmd = new SqlCommand("SELECT  clEmail, clPassword FROM Client where clEmail='" + username + "'", dataBaseObj.sqlconn);
            dataBaseObj.sqlDr = dataBaseObj.sqlCmd.ExecuteReader();
            if (dataBaseObj.sqlDr.Read())
            {
                if (dataBaseObj.sqlDr["clPassword"].Equals(password.ToString()))
                {
                    strmessage = "client";
                    dataBaseObj.sqlconn.Close();
                }
                else
                {
                    intResult++;
                    strmessage = "login  not succesfull";
                    dataBaseObj.sqlconn.Close();
                    if (intResult == 3)
                    {
                        strmessage = "your Blocked";
                    }
                }
            }    // if its not the client is gonna go to workers table 
            else
            {
                dataBaseObj.sqlCmd = new SqlCommand("SELECT wuUsername, wuPassword, wuUserType FROM  WorkUsers where wuUsername'" + username + "'", dataBaseObj.sqlconn);
                dataBaseObj.sqlDr = dataBaseObj.sqlCmd.ExecuteReader();
                if (dataBaseObj.sqlDr.Read())
                {
                    if (dataBaseObj.sqlDr["wuPassword"].Equals(password.ToString()))
                    {
                        strmessage = "Receptionist";
                        dataBaseObj.sqlconn.Close();
                    }
                    else
                    {
                        intResult++;
                         
                        strmessage = "login  not succesful";
                        dataBaseObj.sqlconn.Close();
                        if (intResult == 3)
                        {
                            strmessage = "your Blocked";
                        }
                    }
                }
            }
            return strmessage;
        }
        // this method is for registering the client of the client if not registered
        public string registration(string clID, string clFirstName, string clSurname, string clStreetAddress, string clCity, string clPostCode, string clHomePhone, string clMobilePhone, string clEmail, string clPassword, string clStatus)
        {
            dataBaseObj.sqlconn.Open();
            dataBaseObj.sqlCmd = new SqlCommand("insert into Client values(@clID,@clFirstName@clSurname,@clStreetAddress,@clCity,@clPostCode,@clHomePhone,@clMobilePhone,@clEmail,@clPassword@clStatus)", dataBaseObj.sqlconn);
            dataBaseObj.sqlCmd.Parameters.AddWithValue("@clID", clID);
            dataBaseObj.sqlCmd.Parameters.AddWithValue("@clFirstName", clFirstName);
            dataBaseObj.sqlCmd.Parameters.AddWithValue("@clSurname", clSurname);
            dataBaseObj.sqlCmd.Parameters.AddWithValue("@clStreetAddress", clStreetAddress);
            dataBaseObj.sqlCmd.Parameters.AddWithValue("@clCity", clCity);
            dataBaseObj.sqlCmd.Parameters.AddWithValue("@clPostCode", clPostCode);
            dataBaseObj.sqlCmd.Parameters.AddWithValue("@clHomePhone", clHomePhone);
            dataBaseObj.sqlCmd.Parameters.AddWithValue("@clMobilePhone", clMobilePhone);
            dataBaseObj.sqlCmd.Parameters.AddWithValue("@clEmail", clEmail);
            dataBaseObj.sqlCmd.Parameters.AddWithValue("@clPassword", clPassword);
            dataBaseObj.sqlCmd.Parameters.AddWithValue("@clStatus", clStatus);
            intResult = dataBaseObj.sqlCmd.ExecuteNonQuery();
            if (intResult == 1)
            {
                strmessage = "registeed";
            }
            else
            {
                strmessage = "not registeed";
            }
            return strmessage;
        }
        // this is for the admin to register the the receptionist
        public string AdminRegister(string Id, string username, string password)
        {
            dataBaseObj.sqlconn.Open();
            dataBaseObj.sqlCmd = new SqlCommand("INSERT INTO WorkUsers (wuID, wuUsername, wuPassword) VALUES ('" + Id + "','" + username + "','" + password + "')", dataBaseObj.sqlconn);
            intResult = intResult = dataBaseObj.sqlCmd.ExecuteNonQuery();
            if (intResult == 1)
            {
                strmessage = "registeed";
            }
            else
            {
                strmessage = "not registeed";
            }
            return strmessage;
        }
        // this method is fo receptionist to inser an appoirment
        public string ReceptioInsert(int appID, string appDateNow, string appTimeNow, string appReason, string appDateofBooking, string appTimeofBooking, int clID, int wuID)
        {
            dataBaseObj.sqlconn.Open();
           // appDateNow = Convert.ToString(System.DateTime.Now.Year + "/" + System.DateTime.Now.Month + "/" + System.DateTime.Now.DayOfWeek);
            appDateNow = Convert.ToString(System.DateTime.Now.ToString("m"));
            //appTimeNow = Convert.ToString(System.DateTime.Now.TimeOfDay);
            appTimeNow = Convert.ToString(System.DateTime.Now.ToString("hh:mm:ss"));
            dataBaseObj.sqlCmd = new SqlCommand("SELECT appDateNow, appTimeNow FROM  Appointments where appDateNow='" + appTimeNow + "'AND  where appTimeNow='" + appTimeNow + "'", dataBaseObj.sqlconn);
            if (dataBaseObj.sqlDr.Read())// if it reads it means date and time are booked
            {
                strmessage = "sorry that time is not available";
            }
            else
            {
                dataBaseObj.sqlCmd = new SqlCommand("INSERT INTO Appointments (appID, appDateNow, appTimeNow, appReason, appDateofBooking, appTimeofBooking, clID, wuID) VALUES('" + appID + "','" + appDateNow + "','" + appTimeNow + "','" + appReason + "','" + appDateofBooking + "','" + appTimeofBooking + "','" + clID + "','" + wuID + "')", dataBaseObj.sqlconn);
                intResult = intResult = dataBaseObj.sqlCmd.ExecuteNonQuery();
                if (intResult == 1)
                {
                    strmessage = "registeed";
                }
                else
                {
                    strmessage = "not registeed";
                }
                dataBaseObj.sqlconn.Close();
            }
            return strmessage;
        }
        // this method is to update the appointment
        public void updateAppointmen(int appID, string appDateNow, string appTimeNow, string appReason, string appDateofBooking, string appTimeofBooking, int clID, int wuID)
        {
            dataBaseObj.sqlconn.Open();
            appDateNow = Convert.ToString(System.DateTime.Now.Year + "/" + System.DateTime.Now.Month + "/" + System.DateTime.Now.DayOfWeek);
            appTimeNow = Convert.ToString(System.DateTime.Now.TimeOfDay);
            dataBaseObj.sqlCmd = new SqlCommand("UPDATE Appointments SET  appDateNow =@appDateNow, appTimeNow =@appTimeNow, appReason =@appReason, appDateofBooking =@appDateofBooking, appTimeofBooking =@appTimeofBooking, clID =@clID, wuID =@wuID where appID='" + appID + "'", dataBaseObj.sqlconn);
            dataBaseObj.sqlCmd.Parameters.AddWithValue("@appDateNow", appDateNow);
            dataBaseObj.sqlCmd.Parameters.AddWithValue("@appTimeNow", appTimeNow);
            dataBaseObj.sqlCmd.Parameters.AddWithValue("@appReason", appReason);
            dataBaseObj.sqlCmd.Parameters.AddWithValue("@appDateofBooking", appDateofBooking);
            dataBaseObj.sqlCmd.Parameters.AddWithValue("@appTimeofBooking", appTimeofBooking);
            dataBaseObj.sqlCmd.Parameters.AddWithValue("@clID", clID);
            dataBaseObj.sqlCmd.Parameters.AddWithValue("@wuID", wuID);
            dataBaseObj.sqlCmd.ExecuteNonQuery();
        }
        // this method is to delete the appoinment 
        public void deleteAppointment(int appID)
        {
            dataBaseObj.sqlconn.Open();
            dataBaseObj.sqlCmd = new SqlCommand("DELETE FROM Appointments whre appID='" + appID + "'");
            dataBaseObj.sqlCmd.ExecuteNonQuery();
        }
        // method for client to view the appoinments
        public DataTable CLientViewAppoitnmet(string date)
        {
            dataBaseObj.sqlconn.Open();
            dataBaseObj.sqlAdt = new SqlDataAdapter("SELECT appID, appDateNow, appTimeNow, appReason, appDateofBooking, appTimeofBooking, clID, wuID FROM Appointments where appDateNow='" + date + "'", dataBaseObj.sqlconn);
            dataBaseObj.dt = new DataTable("appoitment");
            dataBaseObj.sqlAdt.Fill(dataBaseObj.dt);
            dataBaseObj.sqlconn.Close();
            return dataBaseObj.dt;
        }
     
