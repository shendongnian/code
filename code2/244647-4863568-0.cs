    public class Item
	{
		public int intServerID { get; set; }
		public string txtName { get; set; }
		public string txtApplicationKey { get; set; }
		public string txtConnectionString { get; set; }
	}
    protected void Page_Load(object sender, EventArgs e)
    {
		Item item = new Item();
		item.intServerID = 1;
		item.txtName = "Apple";
		item.txtApplicationKey = "Orange";
		item.txtConnectionString = "Test";
		List<Item> items = new List<Item>();
		items.Add(item);
		gvwServers.DataSource = items;
		gvwServers.DataBind();
    }
	protected void gvwServers_Edit(object sender, GridViewEditEventArgs e)
	{
		Response.Write("Edit");
		gvwServers.EditIndex = e.NewEditIndex;
		gvwServers.DataBind();
	}
	protected void gvwServers_Updated(object sender, GridViewUpdatedEventArgs e)
	{
		Response.Write("Updated");
		gvwServers.DataBind();
	}
	protected void gvwServers_Updating(object sender, GridViewUpdateEventArgs e)
	{
		Response.Write("Updating");
		gvwServers.DataBind();
	}
	protected void gvwServers_Deleting(object sender, GridViewDeleteEventArgs e)
	{
		Response.Write("Delete");
		gvwServers.DataBind();
	}
	protected void gvwServers_Cancelling(object sender, GridViewCancelEditEventArgs e)
	{
		Response.Write("Cancel");
		e.Cancel = true;
		gvwServers.EditIndex = -1;
		gvwServers.DataBind();
	}
