    protected void rpt_Init(object sender, EventArgs e)
    {
       DAL.InventoryEntities Ie = new DAL.InventoryEntities();
       rpt.DataSource = Ie.Categories;
       rpt.DataBind();
    }
    
    protected void Select_Command(object sender, CommandEventArgs e)
    {
       Response.Write("Hello " + e.CommandArgument);
    }
