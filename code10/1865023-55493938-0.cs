    [HttpGet]
    public IActionResult EmailTemplate()
    {
        EmailTemplateViewModel model = new EmailTemplateViewModel();
        //Load Data here    
        return View(model);       
    }
