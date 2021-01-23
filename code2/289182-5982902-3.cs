    public class AdaTrainingService : ADATraining.Web.Models.IAdaTrainingService, IDisposable
    {
    	private ADATrainingEntities _context = new ADATrainingEntities();
     
    	public IQueryable<EmployeeListItem> GetEmployeeListing()
    	{
    		return from e in _context.Employees
    			   join evsws in EmployeeVideoAggregatesView() on e.Id equals evsws.EmployeeId
    			   select new EmployeeListItem
    			   {
    				   Id = e.Id,
    				   FirstName = e.FirstName,
    				   LastName = e.LastName,
    				   Company = e.Company,
    				   HasWatchedAllVideos = evsws.HasWatchedAllVideos,
    				   StartTime = evsws.StartTime,
    				   EndTime = evsws.EndTime
    			   };
    	}
    
    	private class EmployeeVideoSeriesWatchingStats
    	{
    		public int EmployeeId { get; set; }
    		public DateTime? StartTime { get; set; }
    		public DateTime? EndTime { get; set; }
    		public bool HasWatchedAllVideos { get; set; }
    	}
    
    	private IQueryable<EmployeeVideoSeriesWatchingStats> EmployeeVideoAggregatesView()
    	{
    		return from ev in _context.EmployeeVideos
    			   group ev by ev.EmployeeId into myGroup
    			   select new EmployeeVideoSeriesWatchingStats
    			   {
    				   EmployeeId = myGroup.Key,
    				   StartTime = myGroup.Min( x => x.StartTime),
    				   EndTime = myGroup.Max( x => x.EndTime),
    				   HasWatchedAllVideos = myGroup.Count() ==  _context.Videos.Count()
    			   };
    	}	
    	
    	public void Dispose()
    	{
    		_context.Dispose();
    	}
    }
