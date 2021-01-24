    private void dataGridView1_SelectionChanged(object sender, EventArgs e)
    {
        if (dataGridView1.CurrentRow?.DataBoundItem is Customer customer) {
            List<Order> orders = new List<Order>();
            using (var conn = new SqlConnection(STR_Connection))
            using (var cmd = new SqlCommand("select * from Orders where CustomerID = @cid", conn)) {
                cmd.Parameters.Add("@cid", SqlDbType.Int).Value = customer.CustomerID;
                conn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader()) {
                    while (rdr.Read()) {
                        Order o = new Order();
                        o.OrderID = (int)rdr["OrderID"];
                        o.CustomerID = (int)rdr["CustomerID"];
                        o.OrderDate = (DateTime)rdr["OrderDate"];
                        o.ShipName = (string)rdr["ShipName"];
                        o.ShipCity = (string)rdr["ShipCity"];
                        o.ShipCountry = (string)rdr["ShipCountry"];
                        orders.Add(o);
                    }
                }
            }
            dataGridView2.DataSource = orders;
        } else {
            dataGridView2.DataSource = null;
        }
    }
