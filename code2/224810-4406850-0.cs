    private void PopulateMyRepeatedControl(Chart chart, GetDataSource getDataSource)
    {
        DBUtil DB = new DBUtil();
        DataTable symbols = GetSelectedSymbols();
        DataTable tradeGrades = GetSelectedTradeGrades();
        DataTable executionGrades = GetSelectedExecutionGrades();        
    
        chart.DataSource = getDataSource (
            int.Parse(txtStartBalance.Text),
            int.Parse(ddlTradeTypes.SelectedValue),
            ddlRepeatedTrades.SelectedValue,
            radSide.SelectedValue,
            ddlTradeSetups.SelectedValue,
            symbols,
            ddlChartTimeFrames.SelectedValue,
            int.Parse(ddlHours.SelectedValue),
            int.Parse(ddlYears.SelectedValue),
            int.Parse(ddlMonths.SelectedValue),
            int.Parse(ddlDays.SelectedValue),
            int.Parse(ddlNumSCs.SelectedValue),
            txtDateFrom.Text,
            txtDateTo.Text,
            tradeGrades,
            executionGrades,
            int.Parse(txtMinProfitPips.Text),
            int.Parse(txtMaxProfitPips.Text));
    
        chart.DataBind();
    }
