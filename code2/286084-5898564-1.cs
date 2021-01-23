    protected void ASPxGridView1_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e) {
        if(e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize) { 
            ASPxGridView grid = sender as ASPxGridView;
            double total = 0;
            for(int i = 0; i < grid.VisibleRowCount; i++) 
                if(grid.IsGroupRow(i)) 
                    total += Convert.ToDouble(grid.GetGroupSummaryValue(i, grid.GroupSummary[0]));
            e.TotalValue = total;
            e.TotalValueReady = true;
        }
    }
