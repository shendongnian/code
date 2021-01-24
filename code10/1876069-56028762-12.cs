    /// <summary>
    /// Returns data by the criterion
    /// </summary>
    /// <param name="param">Request sent by DataTables plugin</param>
    /// <returns>JSON text used to display data
    /// <list type="">
    /// <item>sEcho - same value as in the input parameter</item>
    /// <item>iTotalRecords - Total number of unfiltered data. This value is used in the message: 
    /// "Showing *start* to *end* of *iTotalDisplayRecords* entries (filtered from *iTotalDisplayRecords* total entries)
    /// </item>
    /// <item>iTotalDisplayRecords - Total number of filtered data. This value is used in the message: 
    /// "Showing *start* to *end* of *iTotalDisplayRecords* entries (filtered from *iTotalDisplayRecords* total entries)
    /// </item>
    /// <item>aoData - Twodimensional array of values that will be displayed in table. 
    /// Number of columns must match the number of columns in table and number of rows is equal to the number of records that should be displayed in the table</item>
    /// </list>
    /// </returns>
    [Authorize(Roles = "CanViewLab")]
    public ActionResult GetLabs(JQueryDataTableParamModel param, bool isAll)
    {          
        var allRecords = repository.Labs; //All records
        if (!isAll)
        {
            allRecords = allRecords.Where(m => m.StatusId == Status.Active); //Only active records
        };
        IEnumerable<Lab> filteredRecords;
        //Check whether the users should be filtered by keyword
        if (!string.IsNullOrEmpty(param.sSearch))
        {
            //Used if particulare columns are filtered 
            var nameFilter = Convert.ToString(Request["sSearch_1"]);
            var placeFilter = Convert.ToString(Request["sSearch_2"]);
            //Optionally check whether the columns are searchable at all 
            var isNameSearchable = Convert.ToBoolean(Request["bSearchable_1"]);
            var isPlaceSearchable = Convert.ToBoolean(Request["bSearchable_2"]);
            //filteredRecords = repository.Labs
            filteredRecords = allRecords //For including "isAll" parameter to the "filteredRecords" as "allRecords" parameter
                    .Where(c => isNameSearchable && c.Name.ToLower().Contains(param.sSearch.ToLower())
                                ||
                                isPlaceSearchable && c.Place.ToLower().Contains(param.sSearch.ToLower()));
        }
        else
        {
            filteredRecords = allRecords;
        }
        //!!! The number of request variables (bSortable_X) is equal to the iColumns variable.
        var isNameSortable = Convert.ToBoolean(Request["bSortable_1"]);
        var isCodeSortable = Convert.ToBoolean(Request["bSortable_2"]);
        var isStatusNameSortable = Convert.ToBoolean(Request["bSortable_3"]);
        var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
        Func<Lab, string> orderingFunction = (c => sortColumnIndex == 1 && isNameSortable ? c.Name :
                                                        sortColumnIndex == 2 && isCodeSortable ? c.Place :
                                                        sortColumnIndex == 3 && isStatusNameSortable ? c.StatusName :
                                                    "");
        var sortDirection = Request["sSortDir_0"]; // asc or desc
        if (sortDirection == "asc")
            filteredRecords = filteredRecords.OrderBy(orderingFunction);
        else
            filteredRecords = filteredRecords.OrderByDescending(orderingFunction);
        var displayedRecords = filteredRecords.Skip(param.iDisplayStart).Take(param.iDisplayLength);
        var result = from c in displayedRecords select new[] { Convert.ToString(c.Id), c.Name, c.Place, c.StatusName };
        return Json(new
        {
            sEcho = param.sEcho,
            iTotalRecords = allRecords.Count(),
            iTotalDisplayRecords = filteredRecords.Count(),
            aaData = result
        },
        JsonRequestBehavior.AllowGet);
    }
