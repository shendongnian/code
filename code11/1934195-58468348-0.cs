	protected void txtEmployeeNumber_TextChanged(Object sender, EventArgs e) {
		string EmployeeNo = "";
		string EmployeeName = "";
		DataTable dt = (DataTable)Application["Employee_details"];
		var row = (sender as TextBox).NamingContainer as GridViewRow;
		EmployeeNo = (row.FindControl("txtEmployeeNumber") as TextBox).Text;
		var txtEmployeeName = (row.FindControl("txtEmployeeName") as TextBox);
		EmployeeName = txtEmployeeName.Text;
		for (int i = 0; i < dt.Rows.Count; i++) {
			if (dt.Rows[i]["Employee_ID"].ToString() == EmployeeNo) {
				txtEmployeeName.Text = dt.Rows[i]["Employee_Name"].ToString();
				return;
			}
		}
		ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "alert('No Data Found...')", true);
	}
