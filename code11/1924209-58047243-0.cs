        /// <summary>
        /// Import Excel document into the SQL Database and Datagridview
        /// </summary>
        private void ImportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ImportExcelFileDialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel 97 -2003 Workbook|*.xls" })
                {
                    if (ImportExcelFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (var stream = File.Open(ImportExcelFileDialog.FileName, FileMode.Open, FileAccess.Read))
                        {
                            using (IExcelDataReader Reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                DataSet result = Reader.AsDataSet(new ExcelDataSetConfiguration()
                                {
                                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                                });
                                SqlConnection Connection = new SqlConnection(SQL_Commands._Connectionstring);
                                Connection.Open();
                                sqlcommands.DeleteTable(SqliteDatabase[3]);
                                //this is created from a SQL Query file there is only one column and that is ID
                                sqlcommands.RecreateDatabase(Connection);
                                //Get result from Excel file and create a Table from it.
                                tableCollection = result.Tables;
                                DataTable dt = tableCollection[SqliteDatabase[3]];
                               // Create new List
                                List<string> ListColums = new List<string>();
                                //Create columns in SQL Database 
                                foreach(DataColumn column in dt.Columns)
                                {
                                    if(column.ColumnName != "ID")
                                    {
                                        string columnName = "[" + column.ColumnName + "]";
                                        sqlcommands.AddColumn(columnName, SQLite.SqliteDatabase[3], "Text");
                                        //Add Culumn Names to List<string>
                                        ListColums.Add(column.ColumnName);
                                    }
                                }
                                //write already the values to datagridview 
                                InstrumentsBindingSource.DataSource = dt;
                                //Create a connection
                                sqlcommands.ImportFromExcel(Connection,dt, ListColums);
                                sqlcommands.UpdateTableTotal(SQLite.SqliteDatabase[3], InstrumentsBindingSource, dataGridView1);
                            }
                        }
                    }
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.ToString(), "UpdateTableTotal", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void ImportFromExcel(SqlConnection connection,DataTable _dt,List<string> ColumnNames )
        {
            try
            {
                // Get the DataTable 
                DataTable dtInsertRows = _dt;
                using (SqlBulkCopy bulkcopy = new SqlBulkCopy(connection.ConnectionString, SqlBulkCopyOptions.KeepIdentity))
                {
                    bulkcopy.DestinationTableName = "Instruments";
                    bulkcopy.BatchSize = _dt.Rows.Count;
                    foreach (string Column in ColumnNames)
                    {
                        var split = Column.Split(new[] { ',' });
                        bulkcopy.ColumnMappings.Add(split.First(), split.Last());
                    }
                    bulkcopy.WriteToServer(dtInsertRows);
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.ToString(), "InsertBulk", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
