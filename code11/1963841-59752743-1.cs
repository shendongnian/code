    SqlConnection con = null;   //Put this outside your try block
    try
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["PROJECTS"].ConnectionString);
        SqlCommand cmd = new SqlCommand("INSERT INTO tbl_projects (projectName, projectCode, projectDetails) VALUES (@ProjectName, @ProjectCode, @ProjectDetails)");
        cmd.Connection = con;
        con.Open();
        cmd.Parameters.AddWithValue("@ProjectName", txtProjectName.Text);
        cmd.Parameters.AddWithValue("@ProjectCode", txtProjectCode.Text);
        cmd.Parameters.AddWithValue("@ProjectDetails", txtProjectDetails.Text);
        cmd.ExecuteNonQuery();
        Toastr.ShowToast(ex.Message, "Success", Toastr.Type.Success);
    }
    catch (SqlException ex)
    {
        Toastr.ShowToast(ex.Message, "Error:  Oh no, it didn't work!", Toastr.Type.Failed);
    }
    finally
    {
        //Close you connection (if set) in finally.  
        //This way it will also be closed if you do have an exception
        if(con != null)
            con.Close();
    }
