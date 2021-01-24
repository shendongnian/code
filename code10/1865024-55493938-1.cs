    [HttpPost]
    public IActionResult EmailTemplate(EmailTemplateViewModel model)
    {
         if (!ModelState.IsValid)
         {
              **My Code
              return View(model);
          }
          else 
          {
               //populate data here too.
              return View(model);
          }
     }
