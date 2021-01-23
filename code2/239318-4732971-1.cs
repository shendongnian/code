    this.MyGridView.RowDataBound += (s, ea) =>
    {
    	if (ea.Row.Cells[1].Text.Contains(string.Format("{0}/0{1}", DateTime.Now.Day, DateTime.Now.Month)))
    	{
    		ea.Row.BackColor = Color.Red;
    	}
    };
    this.MyGridView.DataBind();	
