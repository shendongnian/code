    public class JobsController: Controller
    {
        public ActionResult Edit()
        {
            var model = new MyViewModel
            {
                // Obviously those will be coming from some data store
                // and you could use AutoMapper to map your business entities
                // to the corresponding view model
                Jobs = new[]
                {
                    new JobViewModel { ID = Guid.NewGuid() },
                    new JobViewModel { ID = Guid.NewGuid() },
                    new JobViewModel { ID = Guid.NewGuid() },
                }
            };
            return View(model);
        }
        [HttpPut]
        public ActionResult Update(MyViewModel model, string activate)
        {
            if (!string.IsNullOrEmpty(activate)) 
            {
                // the Activate button was clicked
            }
            else
            {
                // the Deactivate button was clicked
            }
            // TODO: model.Jobs will contain the checked values => 
            // do something with them like updating a data store or something
            
            // TODO: return some view or redirect to a success action
            return View("Edit", model);
        }
    }
