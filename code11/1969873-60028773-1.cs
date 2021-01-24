    private async void gridView1_DoubleClick(object sender, EventArgs e)
    {                      
        var emp = new Employee {
            FKDetecteur = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FKDetecteur"),
            CreationDate = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CreationDate"),
            OrderNumber gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OrderNumber").ToString(),
            ....
         };
         frmQHSE.EmployeeBindingSource.DataSource = emp;
         frmQHSE.ShowDialog();
    }
