    public ActionResult Details(int id)
    {
    	object o;
    	TempData.TryGetValue("data", out o);
    	var MyModel = JsonConvert.DeserializeObject<T>((string)o);
    	...
    	...
    }
