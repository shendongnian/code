    private void RefreshDropDown()
    {
        string connetionString; SqlConnection cnn;
        SqlCommand cmd;
        cmd = new SqlCommand("exec vfpMRUFiles @exec,'365'", cnn);
        cmd.Parameters.AddWithValue("@exec", Exec.Text);
        SqlDataReader sReader = cmd.ExecuteReader();
        while (sReader.Read())
        {
            string MattResult = sReader["MT05"] + " - " + sReader["MT01"];
            comboBox1.Items.Add(MattResult);
        }
    }
