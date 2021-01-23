    public class ProfileHttpHandler: IHttpHandler
    {
        public int MemberId { get; set; }
    
        public bool IsReusable
        {
            get
            {
                // return value here
            }
        }
    
        public void ProcessRequest(HttpContext context)
        {
            // custom request processing here
        }
    }
