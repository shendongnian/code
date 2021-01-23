        if (!e.CommandName.Equals("Sort")) {
        int searchID = Convert.ToInt32(e.CommandArgument.ToString());
        
        TableAdapters.SuggestionsTableAdapter sAdapt =
            new TableAdapters.SuggestionsTableAdapter();
        SuggestionsDataTable tbl = sAdapt.GetDataByID(searchID);
        tbMessage.Text = tbl.Rows[0]["message"].ToString();
        lbField2.Text = tbl.Rows[0]["field2"].ToString();
        lbStuff.Text = tbl.Rows[0]["stuff"].ToString();
        }
    }
