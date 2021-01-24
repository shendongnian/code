    using (SqlConnection sc = new SqlConnection())
    using (SqlCommand sm = new SqlCommand())
    {
        sc.ConnectionString = "server = ASIR\\SQLEXPRESS; database = elawdb; uid = Asir/Dip; Integrated Security=True";
        sc.Open();
        sm.CommandText = @"
            INSERT INTO Reference_form (DATAFILENAME, ACTFILENAME, ACTTITLE, FORMNUMBER, FORMTITLE, SECTIONREFERENCE, BOOLEANTEXT, COUNTRY)
            VALUES (@DATAFILENAME, @ACTFILENAME, @ACTTITLE, @FORMNUMBER, @FORMTITLE, @SECTIONREFERENCE, @BOOLEANTEXT, @COUNTRY)
        ";
        sm.Parameters.Add(new SqlParameter("@DATAFILENAME", System.Data.SqlDbType.VarChar)).Value = db[0];
        sm.Parameters.Add(new SqlParameter("@ACTFILENAME", System.Data.SqlDbType.VarChar)).Value = db[1];
        sm.Parameters.Add(new SqlParameter("@ACTTITLE", System.Data.SqlDbType.VarChar)).Value = db[2];
        sm.Parameters.Add(new SqlParameter("@FORMNUMBER", System.Data.SqlDbType.VarChar)).Value = db[3];
        sm.Parameters.Add(new SqlParameter("@FORMTITLE", System.Data.SqlDbType.VarChar)).Value = db[4];
        sm.Parameters.Add(new SqlParameter("@SECTIONREFERENCE", System.Data.SqlDbType.VarChar)).Value = db[5];
        sm.Parameters.Add(new SqlParameter("@BOOLEANTEXT", System.Data.SqlDbType.Text)).Value = db[6];
        sm.Parameters.Add(new SqlParameter("@COUNTRY", System.Data.SqlDbType.VarChar)).Value = db[7];
        sm.Connection = sc;
        sm.ExecuteNonQuery();
    }
