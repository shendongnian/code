    private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
    {
    	if (e.Column == colImage1 && e.IsGetData) {
    		string someValueFromDatabase = (string)gridView1.GetRowCellValue(e.RowHandle, colOne);
    		if (someValueFromDatabase == "a") {
    			//Set an icon with index 0
    			e.Value = imageCollection1.Images[0];
    		} else {
    			//Set an icon with index 1
    			e.Value = imageCollection1.Images[1];
    		}
    	}
    }
