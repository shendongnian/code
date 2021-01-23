    public static int totalTracking(int id)
    {
        using (var ctx = new GPEntities())
        {
            return ctx.Tracking.Count(
                      c => c.clientID == Config.ClientID &&
                           c.custID == id &&
                           c.oOrderNum.HasValue);
        }        
    }
