    public ActionResult Submit(MyModel myModel, [Bind(Prefix = "L")] string[] longPropertyName) {
        if(myModel != null) {
    		myModel.LongPropertyName = longPropertyName;
    	}
    }
