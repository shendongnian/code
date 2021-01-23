    DBDataContext db;
    // returns IQueryable<Widget>
    var widgets = GetWidgetQuery(db);
    // adapts the query and it will no longer be compiled
    var widgetsUncompiled = GetWidgetQuery(db).Where(u => u.SomeField.HasValue); 
    // executes the compiled query when enumerated
    var widgetsEnumerable = GetWidgetQuery(db).AsEnumerable(); 
