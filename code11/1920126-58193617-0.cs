    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Builder(int? id, ViewModels.RuleDetail rd, string ignoreChecklists, string command, int? callerId, string callerController, string callerAction)
    {
        //some other logic...
        switch (command)
        {
            //bunch of other command values
            case "UnselectSources":
                foreach (DataSourceCheckList i in rd.dataSourceCheckList)
                {
                    i.IsSelected = false;
                }
                break;
         }
        //update of other view model fields based on actions above
        ModelState.Clear();
        return View(rd);
     }
