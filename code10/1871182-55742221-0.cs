    private void _grd_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e) {
      if (e.Column.FieldName == "TEST") {
        var te = (e.Cell as GridCellInfo).ViewInfo as TextEditViewInfo;
        te.ContextImage = GetCustomImageForThisRow(); // <-- your custom logic 
      }
    }
