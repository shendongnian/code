    private decimal ordersubtotal;
        protected void CalcPriceBtn_Click(object sender, EventArgs e)
        {
            string connectionString1;
            SqlConnection cnn1;
            connectionString1 = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Greenwich_Butchers;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            cnn1 = new SqlConnection(connectionString1);
            string selectSql1 = "SELECT * FROM [OrderLine] WHERE OrderID = ('" + Convert.ToInt32(OrderIDTB.Text) + "')";
            SqlCommand com1 = new SqlCommand(selectSql1, cnn1);
            ordersubtotal = 0.0M;
            try
            {
                cnn1.Open();
                
                using (SqlDataReader read = com1.ExecuteReader())
                {
                    
                    while (read.Read())
                    {
                        
                        decimal rowtotal = Convert.ToDecimal(read["OrderLinePrice"]);
                        ordersubtotal += rowtotal;
                        
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Response.Write("error" + ex.ToString());
            }
            finally
            {
                cnn1.Close();
                OrderPriceTB.Text = ordersubtotal.ToString();
                CreateOrderBtn.Visible = true;
            }
        }
