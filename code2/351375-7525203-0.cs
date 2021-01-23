    private void button2_Click(object sender, EventArgs e)
    {
   	    using (cs)
    	    {
    		cs.Open();
    		using (SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM tblContacts", cs))
    		{
    		    DataTable t = new DataTable();
    		    a.Fill(t);
    
    		    dg.DataSource = t;
    		}
    	    }
    	}
