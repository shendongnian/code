public IActionResult Index()
{
    //Pick switch
    ApiCalls apiCalls = new ApiCalls();
    ViewBag.test = new SelectList(apiCalls.GetLeafSwitchProfiles()); 
    return View();  
}
Now, populate your SelectList by:
<select asp-items="ViewBag.test"></select>
