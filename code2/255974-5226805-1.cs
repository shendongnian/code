[HttpGet]
public ActionResult Edit()
{
    var model = new FilterViewModel 
    { 
        Client = "ClientID-2",
        Physician = "",
        ClientName = new[]
        {
            new SelectListItem { Value = "ClientID-1", Text = "Client Name 1" },
            new SelectListItem { Value = "ClientID-2", Text = "Client Name 2" },
            new SelectListItem { Value = "ClientID-3", Text = "Client Name 3" },
        },
        PhysicianName = new[]
        {
            new SelectListItem { Value = "PhysicianID-1", Text = "Physician Name 1" },
            new SelectListItem { Value = "PhysicianID-2", Text = "Physician Name 2" },
            new SelectListItem { Value = "PhysicianID-3", Text = "Physician Name 3" },
        }
 
   };
    return View(model);
}
