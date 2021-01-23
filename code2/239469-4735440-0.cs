    public class PerfHttpModule : IHttpModule {
    
    	private static Common.Logging.ILog log = Common.Logging.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    	public static readonly string CONTEXT_RequestStart = "PerfHttpModule_RequestStart";
    	public static readonly string CONTEXT_RequestId = "PerfHttpModule_RequestId";
    
    	public void Init(HttpApplication context) {
    		context.BeginRequest += new EventHandler(context_BeginRequest);
    		context.EndRequest += new EventHandler(context_EndRequest);
    	}
    	
    	private void context_BeginRequest(object sender, EventArgs e) {
    		try {
    			if (HttpContext.Current != null) {
    				HttpContext.Current.Items[CONTEXT_RequestStart] = DateTime.Now;
    				HttpContext.Current.Items[CONTEXT_RequestId] = random.Next(999999).ToString("D6");
    				log.Info("Url: " + HttpContext.Current.Request.Url + " (" + HttpContext.Current.Request.ContentLength + ")");
    			}
    		} catch {
    		}
    	}
    	
    	private void context_EndRequest(object sender, EventArgs e) {
    		if (HttpContext.Current.Items.Contains(CONTEXT_RequestStart)) {
    			DateTime time1 = (DateTime)HttpContext.Current.Items[CONTEXT_RequestStart];
    			DateTime time2 = DateTime.Now;
    			double ms = (time2 - time1).TotalMilliseconds;
    			log.Info("TotalMilliseconds: " + ms);
    			if (ms > AppSettings.SlowPage || ms > AppSettings.ErrorSlowPage) {
    				StringBuilder sb = new StringBuilder();
    				sb.Append("Slow page detected." + "\t");
    				sb.Append("TotalMilliseconds: " + ms + "\t");
    				sb.Append("Url: " + HttpContext.Current.Request.Url.ToString());
    				if (ms > AppSettings.ErrorSlowPage) {
    					log.Error(sb.ToString());
    				} else if (ms > AppSettings.SlowPage) {
    					log.Warn(sb.ToString());
    				}
    			}
    		}
    	}
    }
