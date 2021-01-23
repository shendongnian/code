    UIApplication application = commandData.Application;
    Document document = application.ActiveUIDocument.Document;
    
    FilteredElementCollector viewCollector = new FilteredElementCollector(document);
    viewCollector.OfClass(typeof(View));
        
    foreach (Element viewElement in viewCollector)
    {
      View view = (View)viewElement;
      //Do something...
    }
