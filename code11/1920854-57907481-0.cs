    public string Parse(object ViewModel, ControllerContext controller,string tempFilePath,string template)
    {
        try
        {
            var sb = new StringWriter();
            ViewDataDictionary viewData = new ViewDataDictionary();
            pathMapDictionary.Add(tempFilePath, template); // Add template to dictionary which virtual path provider will access
            var tempData = new TempDataDictionary();
            viewData.Model = ViewModel;
            var razor = new RazorView(controller, tempFilePath, null, false, null);
            var viewContext = new ViewContext(controller, razor, viewData, tempData, sb);
            razor.Render(viewContext, sb);
            return sb.ToString();
        }
        catch (Exception exx)
        {
            throw;
        }
    }
