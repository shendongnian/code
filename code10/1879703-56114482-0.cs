    protected void TabulkaZakazkyAktivni_DataBound1(object sender, GridViewRowEventArgs e)
    {
    	if (gvr.RowType == DataControlRowType.DataRow)
    	{
    		if (DateTime.Parse(gvr.Cells[11].Text) < DateTime.Now)
    		{
    			gvr.Cells[11].BackColor = System.Drawing.Color.Red;
    			Label2.Text = Convert.ToString(gvr.Cells[11].Text);
    		}
    	}
    }
