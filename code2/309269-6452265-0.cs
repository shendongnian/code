    public class MyMembershipProvider : SqlMembershipProvider
    {
    
        public override string ApplicationName 
        { 
          get
          {
              var url = HttpContext.Current.Request.Url;
              // find out the application name from  url
          }
          set
          {
             base.ApplicationName = value;
          }
        }
    }
