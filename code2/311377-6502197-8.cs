    tadok.Entities.TList<tadok.Entities.Good> GoodEntites = tadok.Data.DataRepository.GoodProvider.GetAll();
    List<GoodAutoComplete> GoodItems = new List<GoodAutoComplete>();
    foreach (object item_loopVariable in GoodEntites) {
    	item = item_loopVariable;
    	GoodItems.Add(new GoodAutoComplete {
    		ID = item.GodId,
    		label = string.Format(item.GodTitle + "{(0)}", item.GodDescrp).Replace("()", ""),
    		value = string.Format(item.GodTitle + "{(0)}", item.GodDescrp).Replace("()", "")
    	});
    }
    JavaScriptSerializer serializer = new JavaScriptSerializer();
    Values = serializer.Serialize(GoodItems);
    
