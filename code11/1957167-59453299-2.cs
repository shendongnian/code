    using(var check_User_Name= SqlCommand("SELECT count(*) FROM appointmentTable WHERE PatientName = @patname And DoctorName = @docname And AppointmentDateSet = @appointmentdate )", sqlCon)
    {
            
        check_User_Name.Parameters.Add("@patname", DbType.String).Value = patientname;
        check_User_Name.Parameters.Add("@docname", DbType.String).Value = docname;
        check_User_Name.Parameters.Add("@appointmentdate", DbType.DateTime).Value = appointmentdate;        
        con.Open();
        int UserExist = (int)check_User_Name.ExecuteScalar();
        // Followed by your code
    }
