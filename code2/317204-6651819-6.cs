     // Create an SqlConnection to the database.
            using (SqlConnection connection = new SqlConnection(connectionString.ToString()))
            {
                connection.Open();                
               
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM SecureOrders", connection);
                // create the DataSet
                DataSet dataSet = new DataSet();
                // fill the DataSet using our DataAdapter               
                dataAdapter.Fill(dataSet, "SecureOrders");
                DataView source = new DataView(dataSet.Tables[0]);
                DefaultGrid.DataSource = source;
                DefaultGrid.DataBind();
            }
