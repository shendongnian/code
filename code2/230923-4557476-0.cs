    public static System.Collections.Generic.List<string> SQLServerPull()
        {
    		System.Collections.Generic.List<string> Items = new System.Collections.Generic.List<string>();
            string server = "p";
            string database = "IBpiopalog";
            string security = "SSPI";
            string sql = "select server from dbo.ServerList";
            using(SqlConnection con = new SqlConnection("Data Source=" + server + ";Initial Catalog=" + database + ";Integrated Security=" + security))
    		{
    			con.Open();
    			SqlCommand cmd = new SqlCommand(sql, con);
    			SqlDataReader dr = cmd.ExecuteReader();
    			while(dr.Read())
    			{
    				//Add the items to the list.
    				Items.Add(dr[0].ToString());
    				//this below doesnt work because it can't find the comboBox				
    				//comboBox1.Items.Add(dr[0].ToString());
    				//the rest of the code works fine
    			}
    		}
    		//Return the list of items.
    		return Items;
        }
