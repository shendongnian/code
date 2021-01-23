    public JsonResult GetChartData_IncidentsBySiteStatus(string SiteTypeId, string searchTextSite, string StartDate, string EndDate)
    {
    		if (searchTextSite == null)
    				searchTextSite = "";
    
    		DateTime startDate = DateTime.Parse(StartDate);
    		DateTime endDate = DateTime.Parse(EndDate);
    		
    		var  incidentsQry = _db.Incidents;
    		if(SiteTypeId > -1)
    		{
    			incidentsQry = incidentsQry.Where(a=>a.SiteTypeId == SiteTypeId);
    		}
    
    		var qry = from s in _db.Sites   
    							join i in incidentsQry  on s.SiteId equals i.SiteId
    							where s.SiteDescription.Contains(searchTextSite)
    								&& (i.Entered >= startDate && i.Entered <= endDate)
    							group s by s.SiteStatus.SiteStatusDescription + "[" + s.SiteTypeId.ToString() + "]"
    									into grp
    									select new
    									{
    											Site = grp.Key,
    											Count = grp.Count()
    									};
    
    		return Json(qry.ToList()  , JsonRequestBehavior.AllowGet);
    }
