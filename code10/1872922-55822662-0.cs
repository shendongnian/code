      ----AdminPage.aspx-------------
    	 <ItemTemplate>
    	 <asp:Image ID="Image1" ImageUrl="" runat="server" Width="50" Height="50"/>
    	  </ItemTemplate>
    	  
    	  
    	  ----AdminPage.aspx.cs-------------
    	  
    	   protected void Page_Load(object sender, EventArgs e)
        {
    	    string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
           SqlConnection con = new SqlConnection(str);
    	   con.Open();
    	    SqlCommand cmd = new SqlCommand("select Logo from TableName", con);
            cmd.CommandType = CommandType.Text;
    	    SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
    		da.Fill(ds);
    		con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                Image1.ImageUrl = "../PIC/" + ds.Tables[0].Rows[0]["Logo"].ToString();
                
            }
    	}
