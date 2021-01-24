        [HttpGet]
        public ActionResult FormPage()
        {
            //you need to pass the view some data, otherwise your model in your view
            //will be null and you wont get any output (which is what you're seeing now)
            
            ClassIActuallyNeed model = null;
            //hardcoded:
            //model = new ClassIActuallyNeed
            //{ 
            //    Id = 1, 
            //    Html = "<h1>Hello</h1>", 
            //    Version = "something, 
            //    Deleted = false
            //};
            //an example of using your context to fetch your model
            using(var context = new MyDatabase())
            {
                var id = 1
                model = context.ClassIActuallyNeeds.Single(x => x.Id == id);
            }
            return View(model);
        }
