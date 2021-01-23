    public class ListSelectionToolPart : WebPartPages.ToolPart
    {
      private SPWeb _web;
      protected DropDownList ddlLists;
      
      public New(SPWeb Web, string ToolTitle)
      {
	    _web = System.Web;
	    this.Title = ToolTitle;
      }
      protected override void CreateChildControls()
      {
            Literal litLists = new Literal { Text = "<b>List:</b><br />" };
            ddlLists = new DropDownList {
	        AutoPostBack = true,
	        ID = "ddlLists"
            };
            ddlLists.Style.Add("width", "100%");
            foreach (SPList list in _web.Lists)
            {
	         ddlLists.Items.Add(new ListItem(list.Title, list.ID.ToString()));
	        }
            this.Controls.Add(litLists);
            this.Controls.Add(ddlLists);
      }
      public override void ApplyChanges()
      {
	    (this.ParentToolPane.SelectedWebPart as MyWebPart).TargetListGUID = ddlLists.SelectedValue;
      }
    }
