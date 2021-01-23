    String specialField = "Special Field";
    String specialValue = "value";
    SPList list = SPContext.Current.Site.RootWeb.Lists["My List"];
    SPView view = list.Views["My View"]; //This is the view I want to query
    
    SPQuery query = new SPQuery();
    string tmp = view.Query;
    if(tmp.Contains("<Where>")) {
    	//wrap the existing where clause in your needed clause (it should be an And i think)
    	tmp = tmp.Insert(tmp.IndexOf("<Where>") + ("<Where>".Length), "<And><Eq><FieldRef Name='"+specialField+"'/><Value Type='Text'>"+specialValue+"</Value></Eq>");
    	tmp = tmp.Insert(tmp.IndexOf("</Where>"), "</And>");
    } else {
    	//add a where clause if one doesnt exist
    	tmp = "<Where><Eq><FieldRef Name='"+specialField+"'/><Value Type='Text'>"+specialValue+"</Value></Eq></Where>" + tmp;
    }
    query.Query = tmp;
    SPListItemCollection items = list.GetItems(query);
    if(item.Count > 0) {
    	//My value is found. This is what I was looking for.
    	//break out of the loop or return
    } else {
    	//My value is not found.
    }
