    private void dataGridView1_SelectionChanged(object sender, EventArgs e)
    {
        if (dataGridView1.CurrentRow?.DataBoundItem is Customer customer) {
            var orders = new List<Order>();
            using (var conn = new SqlConnection(STR_Connection))
            using (var cmd = new SqlCommand("select * from Orders where CustomerID= @cid", conn)) {
                cmd.Parameters.Add("@cid", SqlDbType.Int).Value = customer.CustomerID;
                conn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader()) {
                    while (rdr.Read()) {
                        var o = new Order {
                            OrderID = (int)rdr["OrderID"],
                            CustomerID = (int)rdr["CustomerID"],
                            OrderDate = (DateTime)rdr["OrderDate"],
                            ShipName = (string)rdr["ShipName"],
                            ShipCity = (string)rdr["ShipCity"],
                            ShipCountry = (string)rdr["ShipCountry"]
                        };
                        orders.Add(o);
                    }
                }
            }
            dataGridView2.DataSource = orders;
        } else {
            dataGridView2.DataSource = null;
        }
    }
