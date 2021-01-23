            try
            { 
                string query = "SELECT customer_ID FROM Customers WHERE ID = 1"; 
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()); 
                conn.Open(); 
                SqlDataAdapter da = new SqlDataAdapter(query, conn); 
                da.Fill(ds);
                listbox1.DataSource = ds.Tables[0];
                listbox1.DataTextField = "WORKSTATION_ID";
                listbox1.DataValueField = "WORKSTATION_ID";
                listbox1.DataBind();
                
            }
            catch (Exception) 
            { 
            }
