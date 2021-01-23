    private void LoadSubjects()
    {
        DataTable subjects = new DataTable();
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT SubjectID, SubjectName FROM Students.dbo.Subjects", con);
            adapter.Fill(subjects);
            ddlSubject.DataSource = subjects;
            ddlSubject.DataTextField = "SubjectNamne";
            ddlSubject.DataValueField = "SubjectID";
            ddlSubject.DataBind();
        }
    }
