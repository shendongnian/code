    public ActionResult DirectoryResult(string search)
    {        
            var groups = _groupService.GetGroupsBySearchExpression(search);
            var premiumGroups = _groupService.FilterPremiumGroups(groups);
            return PartialView(new FundDirectoryViewModel
            {
                Groups = groups,
                PremiumGroups = premiumGroups
            });        
    }
    //optional [AjaxOnly]
    public ActionResult DirectoryAjaxResult( string search )
    {
            TempData[UIMessageDataKeys.FundDirectorySearch] = search;
            return RedirectToAction("Directory", "Group");
    }
