    using(SqlConnection con = new SqlConnection(.......))
    {
        string cmdText = @"SELECT a.AcademicYearID,a.AcademicYear,i.SchoolID 
                           FROM School_AcademicYear a INNER JOIN School_Info i 
                             ON a.AcademicYearID = i.SchoolID  
                          WHERE a.AcademicYearID = @id";
        con.Open();
        adp = new SqlDataAdapter(cmdText, con);
        adp.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = AcademicYearID;
        dt = new DataTable();
        adp.Fill(dt);
        dataGridViewSchoolNMergeAcYear.DataSource = dt;
    }
