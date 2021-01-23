    public ActionResult Index() {
    	var models = SomeService.GetModels(); // returns IEnumerable<YourViewModel>
    	return View(models);
    }
    
    // in your view
    
    @for (int i = 1; i == Model.Count(); i++) {
    	<div id="div-@i">
    		<!-- your content here -->
    	</div>
    }
