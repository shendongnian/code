    private void LoadCustomers(string filter = null) // Optional filter parameter
    {
        string sql = "select * from Customers";
        SqlParameter filterParameter = null;
        if (!String.IsNullOrWhiteSpace(filter)) {
            sql += " WHERE CompanyName LIKE @filter OR ContactName LIKE @filter";
            filterParameter = new SqlParameter("@filter", SqlDbType.NVarChar) {
                Value = "%" + filter + "%" // Add wildcards.
            };
        }
        var Customers = new List<Customer>();
        using (var conn = new SqlConnection(STR_Connection))
        using (var cmd = new SqlCommand(sql, conn)) {
            if (filterParameter != null) {
                cmd.Parameters.Add(filterParameter);
            }
            conn.Open();
            using (var rdr = cmd.ExecuteReader()) {
                while (rdr.Read()) {
                    var c = new Customer() {
                        CustomerID = (string)rdr["CustomerID"],
                        CompanyName = (string)rdr["CompanyName"],
                        ContactName = (string)rdr["ContactName"],
                        City = (string)rdr["City"],
                        Country = (string)rdr["Country"],
                        Phone = (string)rdr["Phone"]
                    };
                    Customers.Add(c);
                }
            }
        }
        dataGridView1.DataSource = Customers;
    }
