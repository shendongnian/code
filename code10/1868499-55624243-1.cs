    //This method will check if the table exist in the ViewState
    //If table does not exist in ViewState, a new table will be created and stored in ViewState
    private DataTable GetDataTable()
    {
        DataTable dt = ViewState["SelectedModels"] as DataTable;
        if (dt == null)
        {
            dt = new DataTable();
            dt.TableName = "ColorData";
            dt.Columns.Add(new DataColumn("Model", typeof(string)));
            dt.Columns.Add(new DataColumn("Price", typeof(string)));
            ViewState["SelectedModels"] = dt;
        }
        return dt;
    }
    //This method will store DataTable to ViewState
    private void SaveDataTable(DataTable dataTable)
    {
        ViewState["SelectedModels"] = dataTable;
    }
    //This method will get the data from the database, add it to the DataTable
    //And it will re-bind the DataTable to the GridView and store the updated DataTable to ViewState
    private void AddItemToList(string modelName, string price)
    {
        string CS = ConfigurationManager.ConnectionStrings["POS_SystemConnectionString2"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            using (SqlCommand cmd =
                new SqlCommand("SELECT * FROM Product_Details WHERE Model = @modelName AND Price = @price", con))
            {
                var modelParameter = new SqlParameter();
                modelParameter.ParameterName = "@modelName";
                modelParameter.Value = modelName;
                cmd.Parameters.Add(modelParameter);
        
                var priceParameter = new SqlParameter();
                priceParameter.ParameterName = "@price";
                priceParameter.Value = price;
                cmd.Parameters.Add(priceParameter);
        
                con.Open();
                using (var sqlReader = cmd.ExecuteReader())
                {
                    var dataTable = GetDataTable();
                    while (sqlReader.Read())
                    {
                        var dataRow = dataTable.NewRow();
                        //Hear I assume that Product_Details table has Model and Price columns
                        //So that sqlReader["Model"] and sqlReader["Price"] will not have any issue.
                        dataRow["Model"] = sqlReader["Model"];
                        dataRow["Price"] = sqlReader["Price"];
                        dataTable.Rows.Add(dataRow);
                    }
                    
                    SaveDataTable(dataTable);
                    GridView1.DataSource = dataTable;
                    GridView1.DataBind();
                }
            }
        }
    }
