    @using <your namespace to UP>
    @model IEnumerable<UP>
    @{
      ViewBag.Title = "Index";
      //Review TempData, it's session data that clears and the end of the next request
      TempData["GenerateFile"] = Model.ToArray();
    }
    ...
    
    @Html.ActionLink("GeneratedFile", "GeneratedFile");
