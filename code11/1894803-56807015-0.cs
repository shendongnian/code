    using (SqlConnection conn = new SqlConnection(@"Data Source=LAP100MK\SQLSERVER;Initial Catalog=HomeBudgetAPP;Integrated Security=True"))
                {
                string category = categoryCombo.SelectedValue.ToString();
                int cid = Int32.Parse(category);
                SqlCommand cmd = new SqlCommand("Get_lines", conn);
                cmd.Parameters.AddWithValue("@Category", cid);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable result = new DataTable();
                da.Fill(result);
                LineCombo.DataSource = result;
                LineCombo.DisplayMember = "Name";
                LineCombo.ValueMember = "Line_id";
                }
