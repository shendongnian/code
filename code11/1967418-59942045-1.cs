     public bool Save_Item_Drop(string Email, string value, string column)
        {
            try
            {
                SqlConnection SQLConn = new SqlConnection(cn);
                SqlCommand cmd = new SqlCommand("spHere", SQLConn);
                bool Success;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Value", value);
                cmd.Parameters.AddWithValue("@Column", column);
                SQLConn.Open();
                Success = Convert.ToBoolean(cmd.ExecuteScalar());
                SQLConn.Close();
                return Success;
            }
            catch (Exception ex)
            {
                string _Product = "White Box Gaming API";
                dynamic _Method = Convert.ToString(System.Reflection.MethodBase.GetCurrentMethod().Name);
                dynamic _Class = Convert.ToString(this.GetType().Name);
                string _Exception = Convert.ToString(ex.ToString());
                Log_Product_Exception(_Product, _Class, _Method, _Exception);
                return false;
            }
        }
