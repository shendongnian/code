    public void UpdateCustomerLastUpdateStatus(Customer c)
    {
        c.LastWebLogIn = DateTime.Now;
        String ipAddress = System.Web.HttpContext.Current.Request.UserHostAddress;
        WebsiteTracking web_track = new WebsiteTracking();
        web_track.User = c;
        web_track.ActiveLoginDate = DateTime.Now;
        web_track.IPAddress = ipAddress;
        this.DataContext.SaveChanges();
    }
