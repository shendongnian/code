            String st = "DELETE FROM supplier WHERE supplier_id =" + textBox1.Text;
            SqlCommand sqlcom = new SqlCommand(st, myConnection);
            try
            {
                sqlcom.ExecuteNonQuery();
                MessageBox.Show("delete successful");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
