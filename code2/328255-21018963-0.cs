     var viewContext = (ViewContext)context;
     if(ViewData.TemplateInfo.HtmlFieldPrefix != string.Empty)
     {
          string fieldId = viewContext.ViewData.TemplateInfo.GetFullHtmlFieldId("");
          fieldId = fieldId.Remove(fieldId.LastIndexOf("_"));
          fieldId = fieldId + "_" + BooleanPropertyName
     }
     else
     {
          string fieldId = BooleanPropertyName
     }
