    public bool InsertRowsToDataBase()
    {
        try
        {
            DataTable excelTable = new DataTable();
            string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + txtExcelFile.Text + "';Extended Properties= 'Excel 8.0;HDR=Yes;IMEX=1'";
            using (OleDbConnection cnn = new OleDbConnection(connString))
            {
                string query = "select * from [Customers$]";
                using (OleDbDataAdapter data = new OleDbDataAdapter(query, cnn))
                {
                    data.Fill(excelTable);
                }
            }
            dgvCustomers.ColumnHeadersVisible = false;
            connString = "Data Source=COMPUTER-8EB749;Initial Catalog=KITS;Integrated Security=true";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                foreach (DataRow row in excelTable.Rows)
                {
                    string ID = row[0];
                    if (ID != null && !String.IsNullOrEmpty(ID.ToString().Trim()))
                    {
                        Int16 CustID = Convert.ToInt16(ID);
                        string CustName = row[1].ToString();
                        string CardScheme = row[2].ToString();
                        string Outlet = row[3].ToString();
                        string TerminalNum = row[4].ToString();
                        Int32 Terminal = Convert.ToInt32(TerminalNum);
                        string Date1 = row[5].ToString();
                        DateTime Date = Convert.ToDateTime(Date1);
                        string Time = row[6].ToString();
                        DateTime DateTime = Convert.ToDateTime(Time);
                        string Amount1 = ds.Tables[0].Rows[i][7].ToString();
                        double Amount = Convert.ToDouble(Amount1);
                        string columnNames = "CustID,CustName,CardScheme,Outlet,TerminalNum,TranDate,TranDateTime,Amount";
                        string query = String.Format("insert into Customer(0}) values ('{1}', '{2}','{3}','{4}','{5}','{6}','{7}','{8}')",
                            columnNames, CustID, CustName, CardScheme, Outlet, Terminal, Date, DateTime, Amount);
                        using (SqlCommand com = new SqlCommand(query, connection))
                        {
                            com.ExecuteNonQuery();
                        }
                    }
                }
            }
            return true;
        }
        catch (Exception exception)
        {
            Elmah.ErrorSignal.FromCurrentContext().Raise(exception);
            return false;
        }
    }
