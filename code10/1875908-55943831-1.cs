    string Insertcmd = "INSERT INTO PatientPay (PatientID, Cash, AmountPaid, 
    PaymentDate, Reseaon, StaffID) Values (@StaffID, @Cash, @AmountPaid, 
            @type, DATEADD(dd, DATEDIFF(dd, 0, getdate()), 0), @StaffID)";
        cmd = new SqlCommand(Insertcmd, con);
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@PatientID", SqlDbType.Int);
        param[0].Value = PatientID;
        param[1] = new SqlParameter("@Cash", SqlDbType.Float);
        param[1].Value = Cash;
        param[2] = new SqlParameter("@AmountPaid", SqlDbType.Float);
        param[2].Value = AmountPaid;
        param[3] = new SqlParameter("@type", SqlDbType.NVarChar, 255);
        param[3].Value = type;
        param[4] = new SqlParameter("@StaffID", SqlDbType.Int, 255);
        param[4].Value = StaffID;
        //Open the connection to database
        con.Open();
        try
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                //Execute the Adding process
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();
             }
         }catch{}
