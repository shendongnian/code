    using (var ctx = new GPEntities())
    {
        return ctx.Tracking
            .Where(c => 
                c.clientID == Config.ClientID &&
                c.custID == id &&
                c.oOrderNum.HasValue)
            .Count();
    }
