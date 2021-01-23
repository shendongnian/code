    DataView SortGridView()
    {
        BankTransactionsDataSet1 dataSet = new BankTransactionsDataSet1();
        BankTransactionsDataClassesDataContext dbc = new BankTransactionsDataClassesDataContext();
        var Definitions = dbc.Definitions;
    
        if (Definitions.Count() <= 0) return null;
        int i = 0;
        foreach (var Definition in Definitions)
        {
            i++;
            string bankName = dbc.Banks.Where(c => c.BankID == Definition.BankID).First().BankName;
            string bankBranch = dbc.Banks.Where(c => c.BankID == Definition.BankID).First().BankBranch;
            dataSet.DataTableBanks.Rows.Add(bankName, Definition.BankAccount,
                Definition.MerchantID, Definition.TerminalID,
                Definition.TransactionKey, Definition.DefinitionID,
                i.ToString(), bankBranch);
        }
    
        string SortExpression = (ViewState["SortExpression"] as string) == null ? "GridViewBankName" : ViewState["SortExpression"] as string;
        string lastDirection = (ViewState["SortDirection"] as string) == null ? "ASC" : ViewState["SortDirection"] as string;
    
        DataView newBankDataTable = new DataView();
        switch (SortExpression)
        {
            case "GridViewTransactionKey":
                if (lastDirection == "ASC")
                    newBankDataTable = dataSet.DataTableBanks.OrderBy(q => q.GridViewTransactionKey).AsDataView();
                else
                    newBankDataTable = dataSet.DataTableBanks.OrderByDescending(q => q.GridViewTransactionKey).AsDataView();
                break;
    
            case "GridViewTerminalID":
                if (lastDirection == "ASC")
                    newBankDataTable = dataSet.DataTableBanks.OrderBy(q => q.GridViewTerminalID).AsDataView();
                else
                    newBankDataTable = dataSet.DataTableBanks.OrderByDescending(q => q.GridViewTerminalID).AsDataView();
                break;
    
            case "GridViewMerchantID":
                if (lastDirection == "ASC")
                    newBankDataTable = dataSet.DataTableBanks.OrderBy(q => q.GridViewMerchantID).AsDataView();
                else
                    newBankDataTable = dataSet.DataTableBanks.OrderByDescending(q => q.GridViewMerchantID).AsDataView();
                break;
    
            case "GridViewBankAccount":
                if (lastDirection == "ASC")
                    newBankDataTable = dataSet.DataTableBanks.OrderBy(q => q.GridViewBankAccount).AsDataView();
                else
                    newBankDataTable = dataSet.DataTableBanks.OrderByDescending(q => q.GridViewBankAccount).AsDataView();
                break;
    
            case "GridViewBankName":
                if (lastDirection == "ASC")
                    newBankDataTable = dataSet.DataTableBanks.OrderBy(q => q.GridViewBankName).AsDataView();
                else
                    newBankDataTable = dataSet.DataTableBanks.OrderByDescending(q => q.GridViewBankName).AsDataView();
                break;
    
            case "GridViewRowNumber":
                if (lastDirection == "ASC")
                    newBankDataTable = dataSet.DataTableBanks.OrderBy(q => int.Parse(q.GridViewRowNumber)).AsDataView();
                else
                    newBankDataTable = dataSet.DataTableBanks.OrderByDescending(q => int.Parse(q.GridViewRowNumber)).AsDataView();
    
                break;
    
            default:
                dataSet.DataTableBanks.DefaultView.Sort = SortExpression + " " + lastDirection;
                break;
        }
    
        return newBankDataTable;
    }
    
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            switch (e.SortExpression)
            {
                case "TransactionKey":
                    ViewState["SortExpression"] = "GridViewTransactionKey";
                    break;
    
                case "TerminalID":
                    ViewState["SortExpression"] = "GridViewTerminalID";
                    break;
    
                case "MerchantID":
                    ViewState["SortExpression"] = "GridViewMerchantID";
                    break;
    
                case "شماره حساب":
                    ViewState["SortExpression"] = "GridViewBankAccount";
                    break;
    
                case "نام بانک":
                    ViewState["SortExpression"] = "GridViewBankName";
                    break;
    
                case "#":
                    ViewState["SortExpression"] = "GridViewRowNumber";
                    break;
    
                default:
                    break;
            }
            string lastDirection = ViewState["SortDirection"] as string;
            string sortDirection = "DESC";
            if ((lastDirection != null) && (lastDirection == "DESC")) sortDirection = "ASC";
            ViewState["SortDirection"] = sortDirection;
    
            GridView1.DataSource = SortGridView();
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            LabelResult.Text = ex.Message;
        }
    }
