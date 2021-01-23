    using (ssDataContext db = new ssDataContext())
    {
        ssDataContext.ObjectTrackingEnabled = false;
        // do your thing here
    }
