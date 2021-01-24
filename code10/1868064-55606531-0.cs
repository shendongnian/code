    try
            {
                SqlConnection myPerformQueryConnection = new SqlConnection("Your Connection String");
                SqlDataAdapter myPerformQueryDataAdapter = new SqlDataAdapter("SELECT Name,Quantity FROM YourTableName", myPerformQueryConnection);
                SqlCommandBuilder myPerformQueryCommandBuilder = new SqlCommandBuilder(myPerformQueryDataAdapter);
                DataTable myPerformQueryDataTable = new DataTable();
                myPerformQueryDataTable.Reset();
                myPerformQueryDataAdapter.Fill(myPerformQueryDataTable);
                if( myPerformQueryDataTable.Rows.Count>0)
                {
                    decimal.TryParse(Convert.ToString(myPerformQueryDataTable.Compute("Sum(Quantity)", "Name='5070'")),out decimal sumObject) ;
                    MessageBox.Show(sumObject.ToString("0.000"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
