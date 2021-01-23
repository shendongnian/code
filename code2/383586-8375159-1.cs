        public System.Data.DataTable GetData()
        {
            System.Data.DataTable table = new System.Data.DataTable();
            string connectionString =
                System.Web.Configuration.WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("GetCars", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(table);
                }
                connection.Close();
            }
            return table;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            gridView.DataSource = GetData();
            gridView.DataBind();
        }
