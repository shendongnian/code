    protected void Page_Load(object sender, EventArgs e)
    {
        // No need to do this here, as you already did it in the markup
        //List<CarouselProducts> CP = CarouselProductsManager.GetCarouselItems(Convert.ToInt32(Session["Mid"]));
        //CategoryMyC.DataSource = CP;
        //This can be assigned in the markup
        //CategoryMyC.ItemDataBound += new  RepeaterItemEventHandler(RepeaterItemDataBound);
        //CategoryMyC.DataBind();
    }
    protected void ddlMcProducts_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList d = (DropDownList)sender;
        // Use d here
    }
    protected void CategoryMyC_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
    
        DropDownList theDropDown = sender as DropDownList;
    
        if (e.Item.ItemType == ListItemType.EditItem)
        {
            DropDownList MyList = (DropDownList)e.Item.FindControl("ddlMcProducts");
           
            // This section is not needed for what you are doing with it:
            // If the control is null, handle it as an error
            // There's no need to give it an event handler if it does exist, because
            // you already did so in the markup
            //if (MyList == null)
            //{
                //System.Windows.Forms.MessageBox.Show("Did not find the controle");
            //}
            //else
                //MyList.SelectedIndexChanged += new EventHandler(MyListIndexChanged);
            //}
        }
    }
    protected void CategoryMyC_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
    
        if (e.CommandSource.GetType() == typeof(DropDownList))
        {
            // Note the correct control name is being passed to FindControl
            DropDownList ddlSomething = (DropDownList)e.Item.FindControl("ddlMcProducts");
            //System.Windows.Forms.MessageBox.Show("I am changing");
            //Now you can access your list that fired the event
            //SomeStaticClass.Update(ddlMcProducts.SelectedIndex);
    }
