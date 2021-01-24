    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = DataList1.SelectedIndex;
        //Your product id should be bound to a label in the item template
        Label lbl = (Label)DataList1.Items[index].FindControl("IDoftheControlcontainingid");
        string id=lbl.Text;
        //use the id variable to get the product and add to cart. your old code
       if (Session["myCart"] == null)
       {
        myCart = new Cart();
        Session["myCart"] = myCart; 
       }
    
    myCart = (Cart)Session["myCart"];
    DataTable dt = ds.SelectQuerey("SELECT * FROM Products where ProductID = '" + id + "'");
    DataRow row = dt.Rows[0];
    myCart.Insert(new CartItem(int.Parse(id), row["ProductName"].ToString(), int.Parse(row["UnitPrice"].ToString()), 1));
    }
