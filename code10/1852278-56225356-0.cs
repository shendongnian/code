    public ActionResult ReadData([DataSourceRequest] DataSourceRequest request, string searchText)
    {
        var data = GetData(searchText);
        // Add a default sort if none is selected, otherwise use the user selected sort
        if (request.Sorts.Count == 0)
        {
            request.Sorts.Add(new SortDescriptor("UserId", ListSortDirection.Ascending));
        }
    
        // Will add `Take`, `Skip`, `OrderBy`, etc. before sending to server
        return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
    }
