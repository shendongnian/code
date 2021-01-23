    var http = System.Web.HttpContext.Current;
    if ((http != null)) {
    	var page = http.CurrentHandler as Web.UI.Page;
    	if ((page != null) && page is Web.UI.Page) {
    		var scriptManager = System.Web.UI.ScriptManager.GetCurrent(page);
    	}
    }
