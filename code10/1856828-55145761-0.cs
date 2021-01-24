                var table = new DataTable("myTable");
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString))
            {
                using (var da = new SqlDataAdapter())
                {
                    da.SelectCommand = new SqlCommand("SELECT * FROM Records", con);
                    da.Fill(ds, "Records");
                }
            }
            dataGridViewPerson.DataSource = table.DefaultView;
