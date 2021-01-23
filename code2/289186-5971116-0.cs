    ActionResult Foo() {
      IEnumerable<MyObject> list = GetList();
    
      switch(Request.QueryString["sortBy"]) {
    	case "Name":
    	  return OrderBy(list, o => o.Name); // <-- SO I CAN MAKE THIS CALL
    	case "TrackingNumber":
    	  return OrderBy(list, o => o.TrackingNumber); // <-- AND THIS ONE
    	default:
    	  return View(list);
      }
    }
    
    ActionResult OrderBy<T>(IEnumerable<MyObject> list, Func<MyObject, T> orderBy) {
    	return View(Request.QueryString["sortDir"] == "d"
    		? list.OrderBy<MyObject, T>(orderBy)
    		: list.OrderByDescending<MyObject, T>(orderBy));
    }
