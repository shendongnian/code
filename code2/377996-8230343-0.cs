        if (!e.CommandName.Equals("Sort")) {
        int searchID = Convert.ToInt32(e.CommandArgument.ToString());
        
        DTE_Forum_Website.DL.DocDataSetTableAdapters.SuggestionsTableAdapter sAdapt =
            new DTE_Forum_Website.DL.DocDataSetTableAdapters.SuggestionsTableAdapter();
        DTE_Forum_Website.DL.DocDataSet.SuggestionsDataTable tbl = sAdapt.GetDataByID(searchID);
        tbMessage.Text = tbl.Rows[0]["message"].ToString();
        lbField2.Text = tbl.Rows[0]["field2"].ToString();
        lbStuff.Text = tbl.Rows[0]["stuff"].ToString();
        }
    }
