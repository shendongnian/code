        public void opencon()
        {
            if (conn == null)
            {
                conn = new SqlConnection(@"Your connection");
            }
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }
        public void Closecon()
        {
            if ((conn != null) && (conn.State == ConnectionState.Open))
            {
                conn.Close();
            }
        }
       public void GetTables(ComboBox cb)
        {
                chuoiketnoi();
                DataTable schema = conn.GetSchema("Tables");
                foreach (DataRow row in schema.Rows)
                {
                    cb.Items.Add(row[2].ToString());
                }
                dongketnoi();
        }
