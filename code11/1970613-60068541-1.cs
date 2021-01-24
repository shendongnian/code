    public static GridBuilder<T> BaseProcessGrid<T>(this GridBuilder<T> helper, DbContext db, string controllerName, string gridName)
       where T : class, IProcessViewModel
    {
        bool showDelete = false;
        var users = db.Users.ToList(); // <--- gets records.
