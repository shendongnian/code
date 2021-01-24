    class ExportJiraViewModel
    {
       public string Message {get;set;}
    }
    public IActionResult ExportJira()
    {
       var vm = new ExportJiraViewModel(); 
       // fill out vm where appropriate
       return View(vm);
    }
