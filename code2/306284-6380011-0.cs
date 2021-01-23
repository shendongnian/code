    public static int totalTracking(int id)
    {
        using (var ctx = new GPEntities())
        {
            var tr = ctx.Tracking
                .Where(c => c.clientID == Config.ClientID)
                .Where(c => c.custID == id)
                .Where(c => c.oOrderNum.HasValue);
            // This can be added above, or left here - the end result is the same
            return tr.Count();
        }        
    }
