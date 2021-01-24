        private void SingleQuoteExample()
        {
            string customerName = "John'Smith";
            SqlWithParameter(customerName); //This works
            SqlWithoutParameter(customerName); //This doesn't because we end up with
            //SELECT * FROM CUSTOMERS WHERE CUSTOMERNAME = 'JOHN'SMITH'
            //Which from SQLs point of view has an extra single quote
        }
        private void SqlWithParameter(string customerName)
        {
            string constr = "DataSource......";
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                string queryStr = "SELECT * FROM CUSTOMERS WHERE CUSTOMERNAME = @CUSTOMERNAME";
                using (SqlCommand cmd = new SqlCommand(queryStr, con))
                {
                    cmd.Parameters.AddWithValue("@CUSTOMERNAME", customerName);
                    //read stuff
                }
            }
        }
        private void SqlWithoutParameter(string customerName)
        {
            string constr = "DataSource......";
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                string queryStr = "SELECT * FROM CUSTOMERS WHERE CUSTOMERNAME = '" + customerName + "'";
                using (SqlCommand cmd = new SqlCommand(queryStr, con))
                {
                    //read stuff
                }
            }
        }
