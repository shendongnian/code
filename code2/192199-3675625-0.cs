        private void button1_Click(object sender, EventArgs e)
        {
            //Create connection string to Excel work book
            string excelConnectionString =
            @"Provider=Microsoft.Jet.OLEDB.4.0;
            Data Source=C:\Test.xls;
            Extended Properties=""Excel 8.0;HDR=YES;""";
            //Create Connection to Excel work book
            OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
            //Create OleDbCommand to fetch data from Excel
            OleDbCommand cmd = new OleDbCommand
            ("Select [Failure_ID], [Failure_Name], [Failure_Date], [File_Name], [Report_Name], [Report_Description], [Error] from [Failures$]", excelConnection);
            excelConnection.Open();
            
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Id", typeof(System.Int32));
            dataTable.Columns.Add("Name", typeof(System.String));
            // TODO: Complete other table columns
            using(OleDbDataReader dReader = cmd.ExecuteReader())
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow["Id"] = dReader.GetInt32(0);
                dataRow["Name"] = dReader.GetString(1);
                // TODO: Complete other table columns
                dataTable.Rows.Add(dataRow);
            }
            SqlBulkCopy sqlBulk = new SqlBulkCopy(strConnection);
            sqlBulk.DestinationTableName = "Failures";
            sqlBulk.WriteToServer(dataTable);
        }
