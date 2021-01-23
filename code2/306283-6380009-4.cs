    using (var ctx = new GPEntities())
    {
        return ctx.Tracking
            .Count(c => 
                c.clientID == Config.ClientID &&
                c.custID == id &&
                c.oOrderNum.HasValue);
    }
