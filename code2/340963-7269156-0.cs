    public static void Main ()
    {
        foreach (Tracking.GetTrackObject method in Tracking.TrackedLists)
        {
            object trackedObject = method();
        }
    }
