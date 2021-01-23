    public virtual string RenderViewToString(
      ControllerContext controllerContext,
      string viewPath,
      string masterPath,
      ViewDataDictionary viewData,
      TempDataDictionary tempData)
    {
      Stream filter = null;
      ViewPage viewPage = new ViewPage();
    
      //Right, create our view
      viewPage.ViewContext = new ViewContext(controllerContext, new WebFormView(viewPath, masterPath), viewData, tempData);
    
      //Get the response context, flush it and get the response filter.
      var response = viewPage.ViewContext.HttpContext.Response;
      response.Flush();
      var oldFilter = response.Filter;
    
      try
      {
          //Put a new filter into the response
          filter = new MemoryStream();
          response.Filter = filter;
    
          //Now render the view into the memorystream and flush the response
          viewPage.ViewContext.View.Render(viewPage.ViewContext, viewPage.ViewContext.HttpContext.Response.Output);
          response.Flush();
    
          //Now read the rendered view.
          filter.Position = 0;
          var reader = new StreamReader(filter, response.ContentEncoding);
          return reader.ReadToEnd();
      }
      finally
      {
          //Clean up.
          if (filter != null)
          {
            filter.Dispose();
          }
    
          //Now replace the response filter
          response.Filter = oldFilter;
      }
    }
