     if (model is ViewDataDictionary)
     {
         controller.ViewData = model as ViewDataDictionary;
     } else {
         controller.ViewData.Model = model;
     }
