    List<Activity> ActivityList = new List<Activity>();
    foreach (Activity activity in ActivityList.FindAll(delegate(Activity a)
        {
            return a.Id == GuidToCompare;
        }))
    {
        //Code here
    }
