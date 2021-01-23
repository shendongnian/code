        public ActionResult WrapperAction()
        {
            // do your initial stuff
            // call your base controller action and cast the result
            // it would be safer to test for various result types and handle accordingly
            ViewResult result = (ViewResult)base.SomeAction();
            object model = result.ViewData.Model;
            // do something with the model
            return result;
        }
