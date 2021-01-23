    public class FooController
    {
        [HttpGet]
        public ActionResult Foo()
        {
            var dateTime = DateTime.Now();
            var model = new Foo 
                            { 
                                Date = dateTime.ToShortDateString(), 
                                Time = dateTime.ToShortTimeString() 
                            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Foo(FooModel model)
        {
            DateTime updatedDateTime;
            var dateTime = string.Format("{0} {1}", model.Date, model.Time);
            var isValid = DateTime.TryParse(dateTime, out updatedDateTime);               
            
            if (!isValid)
            {
                ModelState.AddModelError("Time", "Please enter a valid Time.");
                return View(model);
            }
            // process updates
            return View("Success");
        }
    }
