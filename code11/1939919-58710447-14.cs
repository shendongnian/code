    @using SLMDemo0.Models
    @model IEnumerable<UP>
    @{
      ViewBag.Title = "Index";
      //Review TempData, it's session data that clears at the end of the next request
      TempData["GenerateFile"] = Model.ToArray();
    }
    ...
    
    @Html.ActionLink("GenerateFile", "GenerateFile");
