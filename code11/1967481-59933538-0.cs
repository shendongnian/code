        public void LoadDataEQ()
        {
            DataTable AllDataTable = new DataTable();
            string SqlCommand = "SELECT * FROM Transaction";
            SqlDataAdapter SQLDA = new SqlDataAdapter(SqlCommand , con);
            SQLDA.Fill(AllDataTable);
            SQLDA.Dispose();
            dataGridView1.DataSource = AllDataTable;
        }
