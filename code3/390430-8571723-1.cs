    private ActionResult ShowSummary()
    {
        return RedirectToAction("ShowSummary", new
               {
                   ds = vm.Meta.DataSourceID
               });  
    }
