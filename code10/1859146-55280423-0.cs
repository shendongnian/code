    private void btnUpdate_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection("Server=your_server_name;Database=your_database_name;Trusted_Connection=True;"))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Courses", con))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    {
                        SqlCommandBuilder sqlcmd = new SqlCommandBuilder(da);
                        DataSet ds = new System.Data.DataSet(); // remove this line
                        da.Update(this.ds, "Courses");
                    }
                }
            }
        }
    }
