    public IActionResult AddScheduleItem(string index)
        {
            var myViewData = new ViewDataDictionary(new Microsoft.AspNetCore.Mvc.ModelBinding.EmptyModelMetadataProvider(), new Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary()) 
                             { 
                                { "index", index }
                             };
            PartialViewResult result = new PartialViewResult()
            {
                ViewName = "YourPartialViewName",
                ViewData = myViewData,
            };
            
            return result;
           
        }
