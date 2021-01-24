    public ActionResult Index()
    {
        // Create your model and set the values
        var myModel = new MyClass
        {
            MyProperty = new List<string> { "First Value", "Second Value" }
        };
    
        // Return the model back to your view for access using @Model
        return View(myModel);
    }
