DateTime dateFrom = Convert.ToDateTime(DropDownList1.Text);
            DateTime dateTo = Convert.ToDateTime(DropDownList2.Text);
            string myconstring = ConfigurationManager.ConnectionStrings["KanbanConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(myconstring))
            {
                DataTable dat = new DataTable();
                string find = "SELECT * FROM city WHERE Date BETWEEN @dateFrom AND  @dateTo";
                using (SqlCommand cmd = new SqlCommand(find, conn))
                {
                    cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
                    cmd.Parameters.AddWithValue("@dateTo", dateTo);
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dat);
                    D2.DataSource = dat;
                    D2.DataBind();
                }
            }
