    	protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        	{
	            string ParameterValue1 = ((TextBox)GridView1.Rows[e.RowIndex].Cells[0].Controls[0]).Text;
	            string ParameterValue2 = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text; //Name
	            UpdateOrAddNewRecord(ParameterValue1, ParameterValue2); // call update method
	            GridView1.EditIndex = -1;
        	    BindGridView();
	            Label2.Visible = true;
	            Label2.Text = "Row Updated";
        	}
