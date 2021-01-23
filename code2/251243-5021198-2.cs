    [HttpPost]
    public ActionResult Index(SomeViewModel model)
    {
        // TODO: model.TransactionSplitLines should be properly bound 
        // at least the CategoryId property because it's the only one 
        // you are sending in the post
        ...
    }
