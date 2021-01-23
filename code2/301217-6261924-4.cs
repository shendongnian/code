    protected void RadComboBox1_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
            {
                string sql = "SELECT [SupplierID], [CompanyName], [ContactName], [City] FROM [Suppliers] WHERE CompanyName LIKE @CompanyName + '%'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql,
                    ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString);
                adapter.SelectCommand.Parameters.AddWithValue("@CompanyName", e.Text);
    
                DataTable dt = new DataTable();
                adapter.Fill(dt);
    
                RadComboBox comboBox = (RadComboBox)sender;
                // Clear the default Item that has been re-created from ViewState at this point.
                comboBox.Items.Clear();
    
                foreach (DataRow row in dt.Rows)
                {
                    RadComboBoxItem item = new RadComboBoxItem();
                    item.Text = row["CompanyName"].ToString();
                    item.Value = row["SupplierID"].ToString();
                    item.Attributes.Add("ContactName", row["ContactName"].ToString());
    
                    comboBox.Items.Add(item);
    
                    item.DataBind();
                }
            } 
