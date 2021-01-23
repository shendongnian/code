    public void DeleteSubscription(int id)
    {
        using(var dc = new SubscriptionDataContext())
        {
            var sub = dc.GetById<Subscription>(id);
            if( sub != null ) dc.Delete(sub);
        }
    }
