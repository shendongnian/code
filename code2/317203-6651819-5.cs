    If(!IsPostBack)  // you missed this condition
    {
       orderByString = orderByList.SelectedItem.Value;
         fieldString = searchTextBox.Text;
         string sqlStatement = "SELECT fName,lName,zip,email,cwaSource,price,length FROM SecureOrders WHERE fName LIKE '%" + fieldString + "%' OR lName LIKE'%" + fieldString + "%'  OR zip LIKE'%" + fieldString + "%' OR zip LIKE'%" + fieldString + "%'  OR email LIKE'%" + fieldString + "%' OR cwaSource LIKE'%" + fieldString + "%' OR length LIKE'%" + fieldString + "%' OR price LIKE'%" + fieldString + "%' ORDER BY " + orderByString;
            ////////////////////////////
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.
                OpenWebConfiguration("/Cabot3");
            System.Configuration.ConnectionStringSettings connectionString;
            connectionString = rootWebConfig.ConnectionStrings.ConnectionStrings["secureodb"];
        //TEST
            for (int i = 0; i < DefaultGrid.Rows.Count; i++)
            {
                CheckBox chkUpdate = (CheckBox)DefaultGrid.Rows[i].Cells[1].FindControl("CheckBoxProcess");
                if (chkUpdate != null)
                {
                    OrderBrowser.Text += "Test";
                }
            }
            // Create an SqlConnection to the database.
            using (SqlConnection connection = new SqlConnection(connectionString.ToString()))
            {
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlStatement, connection);
                // create an SqlCommandBuilder - this will automatically generate the
                // commands, and set the appropriate properties in the dataAdapter
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                // create the DataSet
                DataSet dataSet = new DataSet();
                // fill the DataSet using our DataAdapter
                dataAdapter.Fill(dataSet, "SecureOrders");
                SqlCommand cmd = new SqlCommand("SELECT * FROM SecureOrders", connection);  // might not need this
                SqlCommand bitCmd = new SqlCommand("Select IsNull(processed,0) as processedField From SecureOrders", connection);
                DataView source = new DataView(dataSet.Tables[0]);
                DefaultGrid.DataSource = source;
                DefaultGrid.DataBind();
            }
    }
