    using System;
    using System.Web;
    using System.Web.UI;
    using System.Collections.Generic;
    using System.Web.UI.WebControls;
    namespace GridViewDemo
    {
        public partial class Default : System.Web.UI.Page
        {
        	protected void Page_Load(object sender, EventArgs e)
        	{
         		GV.DataSource = GetDataSource();
        		GV.DataBind();
        	}
		protected void GV_RowDataBound(object sender, GridViewRowEventArgs e)
		{
		    if (e.Row.RowType == DataControlRowType.DataRow )
		    {
	            SetCssClass(e.Row);
		        
				if (e.Row.RowIndex % 10 == 0)
				{
					AddHeader (e);            
				}
		    }
		}
		private void SetCssClass(GridViewRow row)
		{
			row.CssClass += ((Entity)row.DataItem).Status;
		}
		private void AddHeader (GridViewRowEventArgs e)
		{
			GridViewRow row = new GridViewRow(e.Row.RowIndex, 0, DataControlRowType.Header, DataControlRowState.Normal);
			
			TableCell cell = new TableCell();
			cell.Controls.Add(new Label { Text = "Id" }); 
			row.Cells.Add(cell);
			
			cell = new TableCell();
			cell.Controls.Add(new Label { Text = "Name" }); 
			row.Cells.Add(cell);
			
			Table tbl = (e.Row.Parent as Table);
			      tbl.Controls.AddAt(e.Row.RowIndex + 1, row);
		}
		
		protected void GV_Sort(object sender, GridViewSortEventArgs e)
		{
			List<Entity> sortedList = GetDataSource();
			if (e.SortExpression == "Id")
			{
				if (e.SortDirection == SortDirection.Ascending)
					sortedList.Sort((x, y) => x.Id.CompareTo(y.Id));
				else
					sortedList.Sort((x, y) => y.Id.CompareTo(x.Id));
			}
			else if (e.SortExpression == "Name")
			{
				if (e.SortDirection == SortDirection.Ascending)
					sortedList.Sort((x, y) => x.Name.CompareTo(y.Name));
				else
					sortedList.Sort((x, y) => y.Name.CompareTo(x.Name));
			}
			
			GV.DataSource = sortedList;
			GV.DataBind();
		}
		
		protected List<Entity> GetDataSource ()
		{
			List<Entity> result = new List<Entity>();
			for (int i = 0; i < 500; i++)
			{
				result.Add(new Entity() { Id=i, Name="foo" });
			}
			
			return result;
		}
	}
    }
