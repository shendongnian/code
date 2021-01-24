        [HttpGet]
        public IActionResult EmailTemplate()
        {
            EmailTemplateViewModel model = new EmailTemplateViewModel();
            
            **Your Code to fetch the data from the database.
    
            return View(model);
        }
