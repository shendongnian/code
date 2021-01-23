    private void LoadSubjects()
    {
        DataTable subjects = new DataTable();
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT SubjectID, SubjectName FROM Students.dbo.Subjects", con);
                adapter.Fill(subjects);
                ddlSubject.DataSource = subjects;
                ddlSubject.DataTextField = "SubjectNamne";
                ddlSubject.DataValueField = "SubjectID";
                ddlSubject.DataBind();
            }
            catch (Exception ex)
            {
                // Handle the error
            }
        }
        // Add the initial item - you can add this even if the options from the
        // db were not successfully loaded
        ddlSubject.Items.Insert(0, new ListItem("<Select Subject>", "0"));
    }
