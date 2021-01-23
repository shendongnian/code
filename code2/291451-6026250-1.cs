      protected void Page_Load(object sender, EventArgs e)
      {
         if (!IsPostBack)
        {
           fillRepeater();
        }
      }
    }
    protected void rptProductList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DropDownList MyDropDown= (DropDownList)e.Item.FindControl("MyRepeater");
            if (MyDropDown!= null)
            {
               MyDropDown.DataSource =   fillDropDown(MyDropDown);
                MyDropDown.DataBind();
            }
        }
    }
  
 
     private DataSet fillDropDown(DropDownList dropDown)
        {
         // get  your collection and return.
        }
    
    protected void DropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList MyDropDown= (DropDownList)sender;
        string item = dropDwon.SelectedValue;
    }
