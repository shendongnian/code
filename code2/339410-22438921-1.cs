    protected void gv_SelectedIndexChanged(object sender, EventArgs e)
    {
            int index = gv.SelectedIndex;
            int vehicleId = Convert.ToInt32(gv.DataKeys[index].Value);
            SqlConnection con = new SqlConnection("-----");
            SqlCommand com = new SqlCommand("DELETE FROM tbl WHERE vId = @vId", con);
            com.Parameters.AddWithValue("@vId", vehicleId);
            con.Open();
            com.ExecuteNonQuery();
    }
