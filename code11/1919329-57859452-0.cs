    DataTable dt;
    void LoadC()
        {
            using (cnx = new SqlConnection("Var_Connection"))
            {
                cnx.Open();
                var adapt = new SqlDataAdapter("select * from Products", cnx);
                dt = new DataTable();
                adapt.Fill(dt);
                comboBox1.DisplayMember = "ProductName";
                comboBox1.ValueMember = "ProductsID";
                comboBox1.DataSource = dt;
            }
        }
