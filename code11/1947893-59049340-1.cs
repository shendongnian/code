    private void AddNewRecordRowToGrid()
    {  
        if (ViewState["EmployeeDetails"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["EmployeeDetails"];
            DataRow drCurrentRow = dtCurrentTable.NewRow();
            drCurrentRow["EmpId"] = txtEmpId.Text;
            drCurrentRow["EmpName"] = txtEmpName.Text;
            drCurrentRow["DeptName"] = txtDeptName.Text;
            drCurrentRow["EmpAddress"] = txtEmpAddress.Text;
            drCurrentRow["EmpSalary"] = txtEmpSalary.Text;
            dtCurrentTable.Rows.Add(drCurrentRow);
            ViewState["EmployeeDetails"] = dtCurrentTable;
            GridView1.DataSource = dtCurrentTable;
            GridView1.DataBind();
        }
    }
