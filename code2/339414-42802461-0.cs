         protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = GridView1.SelectedIndex;
            int id = Convert.ToInt32(GridView1.DataKeys[index].Value);
            SqlConnection con = new SqlConnection(str);
            SqlCommand com = new SqlCommand("spDelete", con);
            com.Parameters.AddWithValue("@PatientId", id);
            con.Open();
            com.ExecuteNonQuery();
