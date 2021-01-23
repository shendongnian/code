    public class HomeController : Controller
    {
    	HockeyStatsEntities db = new HockeyStatsEntities();
    
    	public ActionResult Index()
    	{
    		ViewBag.Message = "League leaders";
    		{
    			return View(db.ListLeagueLeaders());
    		}
    	}
    
    	private ICollection<ListLeagueLeaders_Result> ListLeagueLeaders()
    	{
    		ICollection<ListLeagueLeaders_Result> leagueLeadersCollection = null;
    
    		using (HockeyStatsEntities context = new HockeyStatsEntities())
    		{
    			foreach (ListLeagueLeaders_Result leagueLeader in
    					  context.ListLeagueLeaders())
    			{
    				leagueLeadersCollection.Add(leagueLeader);
    			}
    		}
    		return leagueLeadersCollection;
    	} 
    }
