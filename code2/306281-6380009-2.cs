    using (var ctx = new GPEntities())
    {
        return ctx.Tracking
            .Where(c => c.clientID == Config.ClientID)
            .Where(c => c.custID == id)
            .Where(c => c.oOrderNum.HasValue)
            .Count();
    }
