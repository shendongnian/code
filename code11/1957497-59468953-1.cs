    /* Here we are getting the data from Database */
        public DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
    
            string constring = "";//Your Connection...;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT form_id_pk,form_name,Description FROM tblTableName where form_id_pk='"+Session["userId"] + "'", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using ( dt = new DataTable())
                        {
                            sda.Fill(dt);
                            //dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            return dt;
        }
