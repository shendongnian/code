    protected int CalcPageSummary(ASPxGridView gridView, string fieldName) {
        GridViewDataColumn column = gridView.Columns[fieldName] as GridViewDataColumn;
        if(column == null)
            return 0;
        int pageIndex = gridView.PageIndex;
        int startRowIndex = pageIndex * gridView.SettingsPager.PageSize;
        int finishRowIndex = startRowIndex + gridView.SettingsPager.PageSize;
        if(finishRowIndex > gridView.VisibleRowCount)
            finishRowIndex = gridView.VisibleRowCount;
        int result = 0;
        for(int i = startRowIndex; i < finishRowIndex; i++) 
            result += Convert.ToInt32(gridView.GetRowValues(i, fieldName));
        return result;
    }
    
    private void SetColumnSummary(ASPxGridView gridView, string fieldName) {
        ASPxLabel lbl = gridView.FindFooterCellTemplateControl(gridView.Columns[fieldName], "ASPxLabel1") as ASPxLabel;
        if(lbl != null)
            lbl.Text = CalcPageSummary(gridView, fieldName).ToString();
    }
    protected void ASPxGridView2_BeforeGetCallbackResult(object sender, EventArgs e) {
        SetColumnSummary((ASPxGridView)sender, "UnitPrice");
    }
    protected void ASPxGridView2_BeforePerformDataSelect(object sender, EventArgs e) {
        Session["CategoryID"] = (sender as ASPxGridView).GetMasterRowKeyValue();
    }
    protected void ASPxGridView2_DataBound(object sender, EventArgs e) {
        SetColumnSummary((ASPxGridView)sender, "UnitPrice");
    }
