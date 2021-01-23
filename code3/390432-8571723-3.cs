    private ActionResult ShowSummary(MyViewModel vm)
    {
        return RedirectToAction("ShowSummary", new
               {
                   ds = vm.Meta.DataSourceID
               });  
    }
