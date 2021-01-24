    UIApplication UIapp = commandData.Application;
    UIDocument UIdoc = UIapp.ActiveUIDocument;
    Document doc = UIdoc.Document;
    
    FilteredElementCollector elementCollector = new FilteredElementCollector(doc);
    elementCollector.OfClass(typeof(FamilyInstance));
    
    Selection sel = UIdoc.Selection;
    sel.SetElementIds(elementCollector.ToList().Select(o => o.Id).ToList()); //User selection
