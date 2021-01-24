    private void myGridViewControl_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
    {
        if (!e.Column.FieldName.Equals("ColorName"))
        {
            myGridViewControl.SetRowCellValue(e.RowHandle, e.Column, "MyValue");
        }
    }
