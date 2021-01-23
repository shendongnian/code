    EnvDTE.DTE app = (EnvDTE.DTE)GetService(typeof(SDTE)); 
    if (app.ActiveDocument != null && app.ActiveDocument.Type == "Text")
    {
       EnvDTE.TextDocument text = (EnvDTE.TextDocument)app.ActiveDocument.Object(String.Empty);
       if (!text.Selection.IsEmpty)
       {
          //work with text.Selection.Text
       }
    }
