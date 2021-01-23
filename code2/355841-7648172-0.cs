    using(var web = SPContext.Current.Web)
    {
    	var list = web.Lists[contextList.ID];
    	var query = list.Views[contextView.ID].Query;
    
    	var items = list.GetItems(new SPQuery() { Query = query});
    
    	gridview1.DataSource = items.GetDataTable();
    	gridview1.DataBind();
    }
