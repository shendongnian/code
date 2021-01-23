    protected void gridView1_DataBinding(object sender, GridViewRowEventArgs e)
		{
            if (e.Row.RowType != DataControlRowType.DataRow) return;
                        
			var c = e.Row.FindControl("IdOfControl") as Label;
			if(c != null)
			{
				if (c.Text == "ABC")
					e.Row.BackColor = GetColor("Gray");
				if (c.Text == "BCA")
					e.Row.BackColor = GetColor("Green");
			}
		}
		private Color GetColor(string color)
		{
			return Color.FromName(color);
		}
