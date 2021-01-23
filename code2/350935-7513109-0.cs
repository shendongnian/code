    public partial class WebPage : System.Web.UI.Page
    {
	protected DataTable GridSource
    {
			get	{	return ViewState["GridSource"] as DataTable;	}
			set	
			{	
				ViewState["GridSource"] = value;
				
				gridViewControl.DataSource = value;
				gridViewControl.DataBind();
			}
	}
    
	private void AddRow(DataRow row)
	{
		// Get the lastly binded structure and data
		DataTable tableSource = this.GridSource;
		
		// Add row to data-table "tableSource"
		//..
		
		// Apply the new structure and data
		this.GridSource = tableSource;
	}
    
	// .. Add relevant implementation (methods) for remove, modify operations
	//.. 
    }
