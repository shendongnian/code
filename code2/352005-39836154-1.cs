    public void myfunction(){
            try
            {
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand("sp_laba", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlcon.Close();
            }
    }
