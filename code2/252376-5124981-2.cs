	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Attributes.Add("style", "cursor:help;");
		if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
		{ 
			if (e.Row.RowType == DataControlRowType.DataRow)
			{                
				e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='orange'");
				e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#E56E94'");
				e.Row.BackColor = Color.FromName("#E56E94");                
			}           
		}
		else
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='orange'");
				e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='gray'");
				e.Row.BackColor = Color.FromName("gray");                
			}			
		}
	}
