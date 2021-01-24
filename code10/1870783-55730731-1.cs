     private void Search_btn_Click(object sender, RoutedEventArgs e)
            {
                InvoicesDetails_Grid.Items.Clear();
                foreach (System.Data.DataRowView ZR in InvoicesNumbersCombo.SelectedItems)
                {
                    MySqlConnection conn2 = new MySqlConnection("DataSource='" + DoSomething.Server_Param + "';UserID='" + DoSomething.Uid_Param + "';Password='" + DoSomething.Password_Param + "';Database='" + DoSomething.Database_Param + "';PORT=3306;CHARSET=utf8");
                    conn2.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    MySqlDataReader rd;
                    DataSet ds = new DataSet();
    
                    ds.Clear();
                    cmd.Connection = conn2;
    
                    cmd.CommandText = "SELECT InvoiceNumber,ItemCode,ItemName,Items_QTY,Reservation_Date, " +
                            "EngName,UserName,Address,InvoiceStore,ContsrType,Place FROM Delta_Invoices_Grid where InvoiceNumber  ='" + ZR["InvoiceNumber"] + "'";
                    rd = cmd.ExecuteReader();
    
                    while (rd.Read())
                    {
                        InvoicesDetails_Grid.Items.Add(new MyData()
                        {
                            InvoiceNumber = (rd["InvoiceNumber"].ToString()),
                            ItemCode = (rd["ItemCode"].ToString()),
                            ItemName = rd["ItemName"].ToString(),
                            Items_QTY = (rd["Items_QTY"].ToString()),
                            Reservation_Date = Convert.ToDateTime(rd["Reservation_Date"]),
                            EngName = rd["EngName"].ToString(),
                            UserName = rd["UserName"].ToString(),
                            Address = rd["Address"].ToString(),
                            InvoiceStore = rd["InvoiceStore"].ToString(),
                            ContsrType = rd["ContsrType"].ToString(),
                            Place = rd["Place"].ToString()
                        });
                    }
    
                  
    
                    conn2.Close();
                }
    
    
              
            }
