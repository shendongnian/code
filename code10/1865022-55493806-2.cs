      [HttpPost]
        public IActionResult EmailTemplate(EmailTemplateViewModel model)
        {
            if (!ModelState.IsValid)
            {
             **My Code
            }
               return View(model);
        }
