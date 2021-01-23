        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if(e.Column.FieldName == "Field2")
            {
                var data = gridView1.GetRow(e.RowHandle) as Sample;
                if(data == null)
                    return;
    
                if (data.Field2 < 0)
                    e.Appearance.ForeColor = Color.Red;
            }
        }
