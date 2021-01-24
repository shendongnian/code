    [WebMethod()]
        public void insert_data_to_db_from_local(string partnumber, string srctcode, string dockcode)
        {
            using (SqlConnection conn = new SqlConnection("Server=localhost;UID=sa;PASSWORD=12345678;database=Test;Max Pool Size=400;Connect Timeout=600;"))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"INSERT INTO Hanheld(Part_Number,SRCT_Code,Dock_Code) VALUES(@partnumber,@srctcode,@dockcode)";
                    cmd.Parameters.AddWithValue("@partnumber", partnumber);
                    cmd.Parameters.AddWithValue("@srctcode", srctcode);
                    cmd.Parameters.AddWithValue("@dockcode", dockcode);
                    
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                       // MessgeBox.Show(e.Message.ToString(), "Error Message");
                    }
                }
            }
        }
