    {
    SqlConnection connBadge = new SqlConnection("Data Source =localhost;" +
                       "Initial Catalog = BreastCancer; Integrated Security = SSPI");
        connBadge.Open();
        SqlCommand cmdfBadge = new SqlCommand("SELECT * FROM Products WHERE pid='1'", connBadge);
        var dSet = new DataSet();
       var dt = new Datatable();
       var da = new SqlDataAdapter(cmdfBadge);
        da.Fill(dSet);
        dt = dSet.Tables[0];
        foreach(Datarow a in dt.Rows)
        {
            String pName = a["pName"].ToString();
            String pPrice = a["pPrice"].ToString();
    
            int b = Convert.ToInt16(pPrice);
            int a = Convert.ToInt16(ddQty1.SelectedValue.ToString());
            int g = a * b;
            String Badge = "INSERT into Cart (Name,Price,Quantity,gPrice)  Values(@Name,@Price,@Quantity,@gPrice)";
            SqlCommand cmdBadge = new SqlCommand(Badge, connBadge);
            sqlCommand.Addwithvalue("@Name",pName);
            sqlCommand.Addwithvalue("@Price",b)
            sqlCommand.Addwithvalue("@Quantity",a)
            sqlCommand.Addwithvalue("@gPrice",g)
            cmdBadge.ExecuteNonQuery();
        }
            
    }
        
    
        
            connBadge.Close();
            Response.Redirect("Cart.aspx");
    
    
    }
